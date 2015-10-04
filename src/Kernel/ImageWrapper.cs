using System;
using System.Drawing;
using System.ComponentModel;

namespace Kernel {

    public class ImageWrapper {
        // ENCAPSULATED FIELDS
        private string _filePath;
        private Bitmap _image;
        private bool _statusAdjustable;
        private BackgroundWorker _worker;
        private DoWorkEventArgs _doWorkEventArgs;

        // CONSTRUCTORS
        public ImageWrapper() {
            reset(null);
        }
        public ImageWrapper(string filePath) {
            reset(filePath);
        }

        // INTERFACE
        public string FilePath {
            get {
                return _filePath;
            }
            set {
                _filePath = value;
                _image = null;
            }
        }
        public Bitmap BitmapImage {
            get {
                if (_image != null)
                    return _image;
                if (FilePath != null) {
                    _image = new Bitmap(FilePath);
                    return _image;
                }
                return null;
            }
        }
        public void ApplyFilter(Filter filter, object args, BackgroundWorker worker = null, DoWorkEventArgs e = null) {
            // BackgroundWorker and DoWorkEventArgs must be both null or both non-null
            if ((worker != null) ^ (e != null)) {
                throw new ArgumentException(
                    String.Format("{0} and {1} must be either both null or both non-null", "worker", "e"));
            }

            // Set a flag for whether the filter operation will be able to adjust/report its status
            _statusAdjustable = (worker != null && e != null);
            if (_statusAdjustable) {
                _worker = worker;
                _doWorkEventArgs = e;
            }

            // Perform the requested filter by passing it the provided arguments
            object result = filterResult(filter, args);
            _doWorkEventArgs.Result = result;

            _worker = null;
            _doWorkEventArgs = null;
        }
        public void PerformOperation(Operation op, object args, BackgroundWorker worker, DoWorkEventArgs e) {
            // BackgroundWorker and DoWorkEventArgs must be both null or both non-null
            if ((worker != null) ^ (e != null)) {
                throw new ArgumentException(
                    String.Format("{0} and {1} must be either both null or both non-null", "worker", "e"));
            }

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
        private string renameWithSuffix(string oldFilePath, string suffix) {
            return "";
        }

        // ALGORITHMS
        private ImageWrapper filterResult(Filter filter, object args) {
            // Perform the requested filter by passing it the provided arguments
            ImageWrapper result = null;
            switch (filter) {
                case Filter.Watercolor:
                    WatercolorArgs wa = (WatercolorArgs)args;
                    result = watercolorFilter(new int[1][], 5, 5, wa.WindowSize, wa.SaveUnfiltered);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Return the result of that filter, where applicable
            return result;
        }
        private object operationResult(Operation op, object args) {
            // Perform the requested operation by passing it the provided arguments
            object result = null;
            switch (op) {
                case Operation.RollingBall:
                    RollingBallArgs rba = (RollingBallArgs)args;
                    result = rollingBall(new int[1][], 5, 5, rba.WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Return the result of that operation, where applicable
            return result;
        }
        private ImageWrapper watercolorFilter(int[][] pixels, int width, int height, int winSize, bool saveUnfiltered) {
            for (int s = 0; s < winSize; ++s) {
                System.Threading.Thread.Sleep(500);
                adjustStatus(s + 1, winSize);
            }
            return new ImageWrapper();
        }
        private Rectangle rollingBall(int[][] pixels, int width, int height, int winSize) {
            for (int s = 0; s < winSize; ++s) {
                System.Threading.Thread.Sleep(500);
                adjustStatus(s + 1, winSize);
            }
            return new Rectangle(50, 50, 100, 100);
        }

		// HELPER FUNCTIONS
        private void reset(string filePath) {
            FilePath = filePath;
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
        private string currentTimeStr() {
            return "";
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
