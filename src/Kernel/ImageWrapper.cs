using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Kernel.Properties;

namespace Kernel {

    public class ImageWrapper {
        // ENCAPSULATED FIELDS
        private string _filePath;
        private Bitmap _image;
        private bool _statusAdjustable;
        private BackgroundWorker _worker;
        private DoWorkEventArgs _doWorkEventArgs;
        private static Dictionary<Filter, string> _filterAppends;

        // CONSTRUCTORS
        static ImageWrapper() {
            // Associate each filter with a string to append to file names
            _filterAppends = new Dictionary<Filter, string>() {
                { Filter.Watercolor, Resources.WatercolorFileAppend },
            };
        }
        public ImageWrapper() {
            reset(null);
        }
        public ImageWrapper(string filePath) {
            reset(filePath);
        }

        // INTERFACE
        public string FilePath {
            get { return _filePath; }
        }
        public Bitmap Bitmap {
            get {
                if (_image != null)
                    return _image;
                if (_filePath != null) {
                    _image = new Bitmap(_filePath);
                    return _image;
                }
                return null;
            }
        }
        public void ApplyFilter(Filter filter, FilterArgs args, BackgroundWorker worker = null, DoWorkEventArgs e = null) {
            if (_filePath == null)
                return;

            // BackgroundWorker and DoWorkEventArgs must be both null or both non-null
            if ((worker != null) ^ (e != null))
                throw new ArgumentException($"{nameof(worker)} and {nameof(e)} must be either both null or both non-null");

            // Set a flag for whether the filter operation will be able to adjust/report its status
            _statusAdjustable = (worker != null && e != null);
            if (_statusAdjustable) {
                _worker = worker;
                _doWorkEventArgs = e;
            }

            // Define the Bitmap to be manipulated (either the current image or a copy)
            string newPath = newFilePath(_filePath, _filterAppends[Filter.Watercolor]);
            if (args.SaveUnfiltered)
                File.Copy(_filePath, newPath);
            Bitmap bmp = (args.SaveUnfiltered ? Image.FromFile(newPath) as Bitmap : this.Bitmap);

            // Lock the image's bits and store its pixel data in an array
            Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData data = bmp.LockBits(bounds, ImageLockMode.ReadWrite, bmp.PixelFormat);
            IntPtr ptr = data.Scan0;
            int bytes  = Math.Abs(data.Stride) * bmp.Height;
            byte[] rgbValues = new byte[bytes];
            Marshal.Copy(ptr, rgbValues, 0, bytes);

            // Perform the requested filter by passing it the byte array and arguments
            doApplyFilter(filter, rgbValues, args);
            
            // Copy the RGB values back to the bitmap and unlock the image's bits
            Marshal.Copy(rgbValues, 0, ptr, bytes);
            bmp.UnlockBits(data);
            ImageWrapper result = (args.SaveUnfiltered ? new ImageWrapper(newPath) : this);
            _doWorkEventArgs.Result = result;

            _worker = null;
            _doWorkEventArgs = null;
        }
        public void PerformOperation(Operation op, object args, BackgroundWorker worker = null, DoWorkEventArgs e = null) {
            if (_filePath == null)
                return;

            // BackgroundWorker and DoWorkEventArgs must be both null or both non-null
            if ((worker != null) ^ (e != null))
                throw new ArgumentException($"{nameof(worker)} and {nameof(e)} must be either both null or both non-null");

            // Set a flag for whether the filter operation will be able to adjust/report its status
            _statusAdjustable = (worker != null && e != null);
            if (_statusAdjustable) {
                _worker = worker;
                _doWorkEventArgs = e;
            }

            // Perform the requested operation by passing it the provided arguments
            object result = operationResult(op, args);
            _doWorkEventArgs.Result = result;

            _worker = null;
            _doWorkEventArgs = null;
        }

        // HELPER FUNCTIONS
		private void loadPgmData(string filePath, ref int width, ref int height, ref int maxGrey, int[][] pixels) {

        }
        private string createPgm(string filePath, int width, int height, int maxGrey, int[][] pixels) {
            return "";
        }

        // ALGORITHMS
        private void doApplyFilter(Filter filter, byte[] rgbValues, FilterArgs args) {
            // Perform the requested filter by passing it the provided arguments
            switch (filter) {
                case Filter.Watercolor:
                    WatercolorArgs wa = args as WatercolorArgs;
                    watercolorFilter(wa.WindowSize, wa.SaveUnfiltered);
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
        private object operationResult(Operation op, object args) {
            // Perform the requested operation by passing it the provided arguments
            object result = null;
            switch (op) {
                case Operation.RollingBall:
                    RollingBallArgs rba = (RollingBallArgs)args;
                    result = rollingBall(rba.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Return the result of that operation, where applicable
            return result;
        }
        private void watercolorFilter(int winSize, bool saveUnfiltered) {
            // Process
            for (int s = 0; s < winSize; ++s) {
                System.Threading.Thread.Sleep(500);
                adjustStatus(s + 1, winSize);
            }
        }
        private Rectangle rollingBall(int winSize) {
            for (int s = 0; s < winSize; ++s) {
                System.Threading.Thread.Sleep(500);
                adjustStatus(s + 1, winSize);
            }
            return new Rectangle(435, 120, 30, 30);
        }

		// HELPER FUNCTIONS
        private void reset(string filePath) {
            _filePath = filePath;
            _image = null;
        }
        private void adjustStatus(long currentSteps, long totalSteps) {
            if (!_statusAdjustable)
                return;

            // If a thread-cancelation was requested then cancel the filter
            if (_worker.CancellationPending)
                _doWorkEventArgs.Cancel = true;

            // Otherwise report the current operation's progress
            float percent = 100f * (float)currentSteps / (float)totalSteps;
            _worker.ReportProgress((int)percent);
        }
        private string newFilePath(string oldFilePath, string appendToName) {
            string dirName = Path.GetDirectoryName(oldFilePath);
            string fileName = Path.GetFileNameWithoutExtension(oldFilePath);
            string extension = Path.GetExtension(oldFilePath);
            string newFileName = String.Format("{0}_{1}{2}", fileName, appendToName, extension);
            string newPath = Path.Combine(dirName, newFileName);

            return newPath;
        }
        private void swap(ref int a, ref int n) {

        }
        private int median(int[] window, int size) {
            return 0;
        }
        private void quickSort(int[] window, int size) {

        }
        private void quickSortRecurs(int[] a, int low, int high) {

        }

    }

}
