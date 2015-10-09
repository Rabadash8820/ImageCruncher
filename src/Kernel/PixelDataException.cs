using System;
using System.Drawing.Imaging;

namespace Kernel {

    public class PixelDataException : Exception {
        // CONSTRUCTOR
        public PixelDataException(string message) : base(message) { }

        // PROPERTIES
        public PixelFormat PixelFormat;
        public short BytesPerPixel;
    }

}
