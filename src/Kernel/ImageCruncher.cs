using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Kernel.Args;

namespace Kernel {

    public static class ImageCruncher {
        // ENCAPSULATED FIELDS
        private static bool _statusAdjustable;
        private static BackgroundWorker _worker;
        private static DoWorkEventArgs _doWorkEventArgs;

        // CONSTRUCTORS
        static ImageCruncher() {
        }

        // INTERFACE
        public static void ApplyFilter(Filter filter, ImageArgs args, BackgroundWorker worker = null, DoWorkEventArgs e = null) {
            // BackgroundWorker and DoWorkEventArgs must be both null or both non-null
            if ((worker != null) ^ (e != null))
                throw new ArgumentException($"{nameof(worker)} and {nameof(e)} must be either both null or both non-null");

            // Set a flag for whether the filter operation will be able to adjust/report its status
            _statusAdjustable = (worker != null && e != null);
            if (_statusAdjustable) {
                _worker = worker;
                _doWorkEventArgs = e;
            }

            // Get a List of pixel values from the provided Bitmap
            Bitmap bmp = args.Bitmap;
            Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(bounds, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;
            int numBytes  = Math.Abs(data.Stride) * bmp.Height;
            byte[] bytes = new byte[numBytes];
            Marshal.Copy(ptr, bytes, 0, numBytes);
            bmp.UnlockBits(data);
            List<RgbPixel> pixels = pixelsFromBytes(bytes, bmp.Width, bmp.Height);

            // Perform the requested filter by passing it the pixels and provided arguments
            doApplyFilter(filter, pixels, args);

            // Copy this List of pixel values back into the Bitmap and make it the result
            bytes = bytesFromPixels(pixels);
            Marshal.Copy(bytes, 0, ptr, numBytes);
            _doWorkEventArgs.Result = bmp;

            _worker = null;
            _doWorkEventArgs = null;
        }
        public static void PerformOperation(Operation op, ImageArgs args, BackgroundWorker worker = null, DoWorkEventArgs e = null) {
            // BackgroundWorker and DoWorkEventArgs must be both null or both non-null
            if ((worker != null) ^ (e != null))
                throw new ArgumentException($"{nameof(worker)} and {nameof(e)} must be either both null or both non-null");

            // Set a flag for whether the filter operation will be able to adjust/report its status
            _statusAdjustable = (worker != null && e != null);
            if (_statusAdjustable) {
                _worker = worker;
                _doWorkEventArgs = e;
            }

            // Get a byte array from the provided Bitmap
            Bitmap bmp = args.Bitmap;
            Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(bounds, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;
            int numBytes  = Math.Abs(data.Stride) * bmp.Height;
            byte[] bytes = new byte[numBytes];
            Marshal.Copy(ptr, bytes, 0, numBytes);
            bmp.UnlockBits(data);
            List<RgbPixel> pixels = pixelsFromBytes(bytes, bmp.Width, bmp.Height);

            // Perform the requested operation by passing it the pixels and provided arguments
            object result = operationResult(op, pixels, args);
            _doWorkEventArgs.Result = result;

            _worker = null;
            _doWorkEventArgs = null;
        }

        // ALGORITHMS
        private static void watercolorFilter(List<RgbPixel> pixels, int winSize) {
            // Process
            int length = pixels.Count;
            for (int p = 0; p < length; ++p) {
                if (p % 1000 == 0) {
                    bool keepGoing = adjustStatus(p, length);
                    if (!keepGoing)
                        return;
                }
            }
        }
        private static Rectangle rollingBall(List<RgbPixel> pixels, int winSize) {
            int length = pixels.Count;
            for (long b = 0; b < length; ++b) {
                if (b % 10000 == 0) {
                    bool keepGoing = adjustStatus(b, length);
                    if (!keepGoing)
                        return default(Rectangle);
                }
            }
            return new Rectangle(435, 120, 30, 30);
        }

        // HELPER FUNCTIONS
        private static void loadPgmData(string filePath, ref int width, ref int height, ref int maxGrey, int[][] pixels) {

        }
        private static string createPgm(string filePath, int width, int height, int maxGrey, int[][] pixels) {
            return "";
        }
        private static void doApplyFilter(Filter filter, List<RgbPixel> pixels, ImageArgs args) {
            // Perform the requested filter by passing it the provided arguments
            switch (filter) {
                case Filter.Watercolor:
                    WatercolorArgs wa = args as WatercolorArgs;
                    watercolorFilter(pixels, wa.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        private static object operationResult(Operation op, List<RgbPixel> pixels, object args) {
            // Perform the requested operation by passing it the provided arguments
            object result = null;
            switch (op) {
                case Operation.RollingBall:
                    RollingBallArgs rba = (RollingBallArgs)args;
                    result = rollingBall(pixels, rba.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Return the result of that operation, where applicable
            return result;
        }
        private static bool adjustStatus(long currentSteps, long totalSteps) {
            if (!_statusAdjustable)
                return true;

            // If a thread-cancelation was requested then cancel the filter
            if (_worker.CancellationPending) {
                _doWorkEventArgs.Cancel = true;
                return false;
            }

            // Otherwise report the current operation's progress
            float percent = 100f * (float)currentSteps / (float)totalSteps;
            _worker.ReportProgress((int)percent);
            return true;
        }
        private static List<RgbPixel> pixelsFromBytes(byte[] bytes, int imgWidth, int imgHeight) {
            List<RgbPixel> pixels = new List<RgbPixel>();

            // Calculate the number of bytes per pixel
            int numBytes = bytes.Length;
            int bytesPerPixel = numBytes / (imgWidth * imgHeight);

            // 3 bytes per pixel = RGB
            if (bytesPerPixel == 3) {
                RgbPixel pixel = default(RgbPixel);
                for (long b = 0; b < numBytes; ++b) {
                    int offset = (int)(b % bytesPerPixel);
                    if (offset == 0) {
                        pixel = new RgbPixel();
                        pixel.Red = bytes[b];
                    }
                    else if (offset == 1)
                        pixel.Green = bytes[b];
                    else {
                        pixel.Blue = bytes[b];
                        pixels.Add(pixel);
                    }
                }
            }

            // 4 bytes per pixel = RGBA
            else if (bytesPerPixel == 4) {
                RgbaPixel pixel = default(RgbaPixel);
                for (long b = 0; b < numBytes; ++b) {
                    int offset = (int)(b % bytesPerPixel);
                    if (offset == 0) {
                        pixel = new RgbaPixel();
                        pixel.Red = bytes[b];
                    }
                    else if (offset == 1)
                        pixel.Green = bytes[b];
                    else if (offset == 2)
                        pixel.Blue = bytes[b];
                    else {
                        pixel.Alpha = bytes[b];
                        pixels.Add(pixel);
                    }
                }
            }

            // Otherwise, throw an exception
            else
                throw new PixelDataException($"ImageWrapper only understands PixelFormats with 3 or 4 bytes per pixel, not {bytesPerPixel}.");

            return pixels;
        }
        private static byte[] bytesFromPixels(List<RgbPixel> pixels) {
            // Determine whether these are RGB or RGBA pixels
            int numPixels = pixels.Count;
            bool hasAlpha = (pixels[0] is RgbaPixel);
            int bytesPerPixel = (hasAlpha ? 4 : 3);

            // Populate an array of bytes from these pixels
            int b=-1;
            byte[] bytes = new byte[numPixels * bytesPerPixel];
            for (int p = 0; p < numPixels; ++p) {
                bytes[++b] = pixels[p].Red;
                bytes[++b] = pixels[p].Green;
                bytes[++b] = pixels[p].Blue;
                if (hasAlpha)
                    bytes[++b] = (pixels[p] as RgbaPixel).Alpha;
            }

            return bytes;
        }
        private static int median(int[] window, int size) {
            return 0;
        }

    }

}
