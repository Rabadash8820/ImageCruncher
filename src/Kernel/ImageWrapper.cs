using System.Drawing;

namespace Kernel {

    public class ImageWrapper {
        // ENCAPSULATED FIELDS
        private string _filePath;
        private Bitmap _image;

        // CONSTRUCTORS
        public ImageWrapper() {
            reset(null, false);
        }
        public ImageWrapper(string filePath, bool showOutput = false) {
            reset(filePath, showOutput);
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
        public bool ShowOutput { get; set; }
        public void Watercolor(int winSize) {
            
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

		// FILTER ALGORITHM FUNCTIONS
        private void watercolorFilter(int[][] pixels, int width, int height, int winSize) {

        }

		// HELPER FUNCTIONS
        private void reset(string filePath, bool showOutput) {
            FilePath = filePath;
            ShowOutput = showOutput;
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
