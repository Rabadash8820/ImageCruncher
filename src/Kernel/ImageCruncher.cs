using System;
using System.Linq;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using Kernel.Args;

namespace Kernel {

    public static class ImageCruncher {
        // HIDDEN FIELDS
        private static Random _rand;
        private static bool _statusAdjustable;
        private static BackgroundWorker _worker;
        private static DoWorkEventArgs _doWorkEventArgs;
        private static long _totalSteps;

        // ABSTRACT DATA TYPES
        private struct RollingBallContext {
            public RgbPixel[,] Pixels { get; set; }
            public int NumRows { get; set; }
            public int NumColumns { get; set; }
            public int NumWindowRows { get; set; }
            public int NumWindowColumns { get; set; }
            public int NumWindows { get; set; }
            public int NumWindowPixels { get; set; }
            public int WindowSideLength { get; set; }
            public int ReportIncrement { get; set; }
            public Color OptimalColor { get; set; }
        }

        // CONSTRUCTORS
        static ImageCruncher() {
            _rand = new Random();
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
            RgbPixel[,] pixels = pixelsFromBytes(bytes, bmp.Width, bmp.Height);

            // Perform the requested filter by passing it the pixels and provided arguments
            doApplyFilter(filter, ref pixels, args);

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
            RgbPixel[,] pixels = pixelsFromBytes(bytes, bmp.Width, bmp.Height);

            // Perform the requested operation by passing it the pixels and provided arguments
            object result = operationResult(op, pixels, args);
            _doWorkEventArgs.Result = result;

            _worker = null;
            _doWorkEventArgs = null;
        }

        // ALGORITHMS
        private static void watercolorFilter(ref RgbPixel[,] pixels, int winSize) {
            // Make a new array to hold the filtered pixels
            int numRows = pixels.GetLength(0);
            int numCols = pixels.GetLength(1);
            RgbPixel[,] fPixels = new RgbPixel[numRows, numCols];
            _totalSteps = numRows;

            // Loop over each pixel
            int checkRows = numRows / 100;
            for (int row = 0; row < numRows; ++row) {
                for (int col = 0; col < numCols; ++col) {
                    if (isCancelled())
                        return;

                    // Create a window around this pixel
                    int numWinPixels = 0;
                    int bound = winSize / 2;
                    RgbPixel[] window = new RgbPixel[winSize * winSize];
                    for (int rOffset = -bound; rOffset <= bound; ++rOffset) {
                        for (int cOffset = -bound; cOffset <= bound; ++cOffset) {
                            int r = row + rOffset;
                            int c = col + cOffset;
                            if ((0 <= r && r < numRows) && (0 <= c && c < numCols))
                                window[numWinPixels++] = pixels[r, c];
                        }
                    }

                    // Set the value of the filtered pixel at this position to the median values of the window
                    window = window.Take(numWinPixels).ToArray();
                    RgbPixel med = median(window, numWinPixels);
                    fPixels[row, col] = med;
                }

                // Report status after every couple rows
                if (row % checkRows == 0)
                    reportProgress(row);
            }

            // Store the array of filtered pixels back into the original array and delete the former
            pixels = fPixels;
        }
        private static Rectangle rollingBall(RgbPixel[,] pixels, int winSize, Color optimalColor) {
            // Initialize the context for this run of the RollingBall operation
            RollingBallContext context = new RollingBallContext() {
                Pixels = pixels,
                NumRows = pixels.GetLength(0),
                NumColumns = pixels.GetLength(1),
                NumWindowPixels = winSize * winSize,
                WindowSideLength = winSize,
                OptimalColor = optimalColor,
            };
            int numRows = context.NumRows;
            context.NumWindowRows = numRows - winSize + 1;
            context.NumWindowColumns = context.NumColumns - winSize + 1;
            context.NumWindows = context.NumWindowRows * context.NumWindowColumns;
            context.ReportIncrement = numRows / 50;
            _totalSteps = numRows + context.NumWindowRows;    // (Row sum steps) + (window sum steps)

            // Get the pixel sums for each row of every possible window
            // Use those sums to calculate the pixel sums for each entire window
            // Return the window whose average color was the minimum distance from the optimal color in color space
            long[,] rowSumsR;
            long[,] rowSumsG;
            long[,] rowSumsB;
            bool stillGoing = getWindowRowSumsAsync(context, out rowSumsR, out rowSumsG, out rowSumsB);
            if (!stillGoing)
                return default(Rectangle);
            Rectangle minRect = getMinWindow(context, rowSumsR, rowSumsG, rowSumsB);
            return minRect;
        }
        
        // HELPER FUNCTIONS
        private static void loadPgmData(string filePath, ref int width, ref int height, ref int maxGrey, int[][] pixels) {

        }
        private static string createPgm(string filePath, int width, int height, int maxGrey, int[][] pixels) {
            return "";
        }
        private static void doApplyFilter(Filter filter, ref RgbPixel[,] pixels, ImageArgs args) {
            // Perform the requested filter by passing it the provided arguments
            switch (filter) {
                case Filter.Watercolor:
                    WatercolorArgs wa = args as WatercolorArgs;
                    watercolorFilter(ref pixels, wa.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        private static object operationResult(Operation op, RgbPixel[,] pixels, object args) {
            // Perform the requested operation by passing it the provided arguments
            object result = null;
            switch (op) {
                case Operation.RollingBall:
                    RollingBallArgs rba = (RollingBallArgs)args;
                    result = rollingBall(pixels, rba.WindowSize, rba.OptimalColor);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Return the result of that operation, where applicable
            return result;
        }
        private static bool getWindowRowSumsAsync(RollingBallContext context, out long[,] sumsR, out long[,] sumsG, out long[,] sumsB) {
            // Initialize color component sums
            int numRows = context.NumRows;
            int winCols = context.NumWindowColumns;
            sumsR = new long[numRows, winCols];
            sumsG = new long[numRows, winCols];
            sumsB = new long[numRows, winCols];

            // Loop over each row of every possible window to get those row sums
            for (int row = 0; row < numRows; ++row) {
                for (int col = 0; col < winCols; ++col) {
                    if (isCancelled())
                        return false;

                    // Cache the pixel RGB sums of that row
                    sumsR[row, col] = sumsG[row, col] = sumsB[row, col] = 0;
                    for (int c = 0; c < context.WindowSideLength; ++c) {
                        RgbPixel p = context.Pixels[row, col + c];
                        sumsR[row, col] += p.Red;
                        sumsG[row, col] += p.Green;
                        sumsB[row, col] += p.Blue;
                    }

                }

                // Report status after every couple rows
                if (row % context.ReportIncrement == 0)
                    reportProgress(row + 1);
            }

            return true;    // Thread hasn't been cancelled
        }
        private static Rectangle getMinWindow(RollingBallContext context, long[,] sumsR, long[,] sumsG, long[,] sumsB) {
            // Loop over each window row sum to get total RGB sums for each possible window
            Rectangle minRect = new Rectangle(0, 0, context.WindowSideLength, context.WindowSideLength);
            double minSqrDistance = double.MaxValue;
            for (int row = 0; row < context.NumWindowRows; ++row) {
                for (int col = 0; col < context.NumWindowColumns; ++col) {
                    if (isCancelled())
                        return default(Rectangle);

                    // Define a pixel with RGB values that are averages of the whole window
                    long red = 0, green = 0, blue = 0;
                    for (int r = 0; r < context.WindowSideLength; ++r) {
                        red += sumsR[row + r, col];
                        green += sumsG[row + r, col];
                        blue += sumsB[row + r, col];
                    }
                    int winPixels = context.NumWindowPixels;
                    Color avgColor = Color.FromArgb((int)(red / winPixels), (int)(green / winPixels), (int)(blue / winPixels));

                    // Determine if this window's average color is the new minimum distance from the optimal color, in color space
                    int colorSqrDist = colorDistanceSqr(avgColor, context.OptimalColor);
                    if (colorSqrDist < minSqrDistance) {
                        minSqrDistance = colorSqrDist;
                        minRect.Y = row + 1;
                        minRect.X = col + 1;
                    }
                }

                // Report status after every couple rows
                if (row % context.ReportIncrement == 0)
                    reportProgress(context.NumRows + row + 1);
            }

            return minRect;
        }
        private static bool isCancelled() {
            bool cancelled = false;

            // If a thread-cancelation was requested then cancel the filter
            if (_statusAdjustable && _worker.CancellationPending) {
                _doWorkEventArgs.Cancel = true;
                cancelled = true;
            }

            return cancelled;
        }
        private static void reportProgress(long currentSteps) {
            if (!_statusAdjustable)
                return;            

            // Report the current operation's progress
            float percent = 100f * (float)currentSteps / (float)_totalSteps;
            _worker.ReportProgress((int)percent);
        }
        private static RgbPixel[,] pixelsFromBytes(byte[] bytes, int imgWidth, int imgHeight) {
            RgbPixel[,] pixels = new RgbPixel[imgHeight, imgWidth];

            // Calculate the number of bytes per pixel
            int numBytes = bytes.Length;
            int bytesPerPixel = numBytes / (imgWidth * imgHeight);
            bool hasAlpha = (bytesPerPixel == 4);

            // We can only handle 3 bytes per pixel (RGB) or 4 bytes per pixel (RGBA)
            if (bytesPerPixel != 3 && bytesPerPixel != 4)
                throw new PixelDataException($"ImageWrapper only understands PixelFormats with 3 or 4 bytes per pixel, not {bytesPerPixel}.");

            // Loop over each byte to create a 2D array of pixel data
            bool pixelMade = false;
            RgbPixel pixel = default(RgbPixel);
            for (int b = 0; b < numBytes; ++b) {
                // Define the RGB(A) members of this pixel
                int offset = (int)(b % bytesPerPixel);
                if (offset == 0) {
                    pixel = (hasAlpha ? new RgbaPixel() : new RgbPixel());
                    pixel.Blue = bytes[b];
                }
                else if (offset == 1)
                    pixel.Green = bytes[b];
                else if (offset == 2) {
                    pixel.Red = bytes[b];
                    pixelMade = !hasAlpha;
                }
                else {
                    (pixel as RgbaPixel).Alpha = bytes[b];
                    pixelMade = true;
                }

                // Add the pixel to the matrix
                if (pixelMade) {
                    int p = b / bytesPerPixel;
                    int row = p / imgWidth;
                    int col = p % imgWidth;
                    pixels[row, col] = pixel;
                }
            }

            return pixels;
        }
        private static byte[] bytesFromPixels(RgbPixel[,] pixels) {
            // Determine whether these are RGB or RGBA pixels
            int numRows = pixels.GetLength(0);
            int numCols = pixels.GetLength(1);
            bool hasAlpha = (pixels[0, 0] is RgbaPixel);
            int bytesPerPixel = (hasAlpha ? 4 : 3);

            // Populate an array of bytes from these pixels
            int b=-1;
            byte[] bytes = new byte[numRows * numCols * bytesPerPixel];
            for (int r = 0; r < numRows; ++r) {
                for (int c=0; c < numCols; ++c) {
                    bytes[++b] = pixels[r, c].Blue;
                    bytes[++b] = pixels[r, c].Green;
                    bytes[++b] = pixels[r, c].Red;
                    if (hasAlpha)
                        bytes[++b] = (pixels[r, c] as RgbaPixel).Alpha;
                }
            }

            return bytes;
        }
        private static RgbPixel median(RgbPixel[] window, int size) {
            // Check whether the window size is odd and whether we're using RGB or RGBA pixels
            bool hasAlpha = (window[0] is RgbaPixel);
            RgbPixel pixel = (hasAlpha ? new RgbaPixel() : new RgbPixel());
            bool odd = (size % 2 == 1);

            // Set this pixel's values as the median of all values in the window
            RgbPixel[] temp;
            int first = size / 2;
            int second = size / 2 + 1;
            temp = window.OrderBy(p => p.Red).ToArray();
            pixel.Red = (byte)(odd ? temp[first].Red : (temp[first].Red + temp[second].Red) / 2);
            temp = window.OrderBy(p => p.Green).ToArray();
            pixel.Green = (byte)(odd ? temp[first].Green : (temp[first].Green + temp[second].Green) / 2);
            temp = window.OrderBy(p => p.Blue).ToArray();
            pixel.Blue = (byte)(odd ? temp[first].Blue : (temp[first].Blue + temp[second].Blue) / 2);
            if (hasAlpha) {
                RgbaPixel[] tempA = window.Select(p => p as RgbaPixel).OrderBy(pa => pa.Alpha).ToArray();
                (pixel as RgbaPixel).Alpha = (byte)(odd ? tempA[first].Alpha : (tempA[first].Alpha + tempA[second].Alpha) / 2);
            }

            return pixel;
        }
        private static int colorDistanceSqr(Color c1, Color c2) {
            int dr = c2.R - c1.R;
            int dg = c2.G - c1.G;
            int db = c2.B - c1.B;
            return dr*dr + dg*dg + db*db;   // Faster than computing a square root
        }

    }

}
