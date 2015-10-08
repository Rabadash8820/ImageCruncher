using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

using Kernel.Args;

namespace Kernel {

    public static class ImageWrapper {
        // ENCAPSULATED FIELDS
        private static bool _statusAdjustable;
        private static BackgroundWorker _worker;
        private static DoWorkEventArgs _doWorkEventArgs;

        // CONSTRUCTORS
        static ImageWrapper() {
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

            // Get a byte array from the provided Bitmap
            Bitmap bmp = args.Bitmap;
            Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(bounds, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;
            int numBytes  = Math.Abs(data.Stride) * bmp.Height;
            byte[] bytes = new byte[numBytes];
            Marshal.Copy(ptr, bytes, 0, numBytes);
            bmp.UnlockBits(data);

            // Perform the requested filter by passing it the byte array and arguments
            doApplyFilter(filter, bytes, args);
            
            // Copy this byte array back into the Bitmap and make it the result
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

            // Perform the requested operation by passing it the provided arguments
            object result = operationResult(op, bytes, args);
            _doWorkEventArgs.Result = result;

            _worker = null;
            _doWorkEventArgs = null;
        }

        // HELPER FUNCTIONS
		private static void loadPgmData(string filePath, ref int width, ref int height, ref int maxGrey, int[][] pixels) {

        }
        private static string createPgm(string filePath, int width, int height, int maxGrey, int[][] pixels) {
            return "";
        }

        // ALGORITHMS
        private static void doApplyFilter(Filter filter, byte[] bytes, ImageArgs args) {
            // Perform the requested filter by passing it the provided arguments
            switch (filter) {
                case Filter.Watercolor:
                    WatercolorArgs wa = args as WatercolorArgs;
                    watercolorFilter(bytes, wa.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        private static object operationResult(Operation op, byte[] bytes, object args) {
            // Perform the requested operation by passing it the provided arguments
            object result = null;
            switch (op) {
                case Operation.RollingBall:
                    RollingBallArgs rba = (RollingBallArgs)args;
                    result = rollingBall(bytes, rba.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Return the result of that operation, where applicable
            return result;
        }
        private static void watercolorFilter(byte[] rgbValues, int winSize) {
            // Process
            long length = rgbValues.LongLength;
            for (long b = 0; b < length; ++b) {
                rgbValues[b] = 0;
                if (b % 10000 == 0) {
                    bool keepGoing = adjustStatus(b, length);
                    if (!keepGoing)
                        return;
                }
            }
        }
        private static Rectangle rollingBall(byte[] rgbValues, int winSize) {
            long length = rgbValues.LongLength;
            for (long b = 0; b < length; ++b) {
                rgbValues[b] = 0;
                if (b % 10000 == 0) {
                    bool keepGoing = adjustStatus(b, length);
                    if (!keepGoing)
                        return default(Rectangle);
                }
            }
            return new Rectangle(435, 120, 30, 30);
        }

        // HELPER FUNCTIONS
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
        private static void swap(ref int a, ref int n) {

        }
        private static int median(int[] window, int size) {
            return 0;
        }
        private static void quickSort(int[] window, int size) {

        }
        private static void quickSortRecurs(int[] a, int low, int high) {

        }

    }

}
