using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using Kernel;
using GuiShell.Properties;

namespace GuiShell {

    public static class Util {
        private static Dictionary<Filter, string> _filterAppends;

        static Util() {
            // Associate each filter with a string to append to file names
            _filterAppends = new Dictionary<Filter, string>() {
                { Filter.Watercolor, Resources.WatercolorFileAppend },
            };
        }

        // INTERFACE
        public static Bitmap BitmapFromFile(string filePath, bool saveUnfiltered) {
            // Define the Bitmap to be manipulated (either the current image or a copy)
            string newPath = newFilePath(filePath, _filterAppends[Filter.Watercolor]);
            if (saveUnfiltered)
                File.Copy(filePath, newPath);
            Bitmap bmp = Image.FromFile(newPath) as Bitmap;

            // Return the image's BitmapData
            //Rectangle bounds = new Rectangle(0, 0, bmp.Width, bmp.Height);
            //BitmapData data = bmp.LockBits(bounds, ImageLockMode.ReadWrite, bmp.PixelFormat);

            return bmp;
        }

        // HELPER FUNCTIONS
        private static string newFilePath(string oldFilePath, string appendToName) {
            // Get the parts of the old file path
            string dirName = Path.GetDirectoryName(oldFilePath);
            string fileName = Path.GetFileNameWithoutExtension(oldFilePath);
            string extension = Path.GetExtension(oldFilePath);  // includes the dot

            // Create a new unique path by adding numeric suffixes (e.g., "filename_append(3).ext")
            int f=1;
            string newFileName = $"{fileName}_{appendToName}";
            string newPath = Path.Combine(dirName, $"{newFileName}{extension}");
            while (File.Exists(newPath)) {
                newFileName = $"{newFileName}({f})";
                newPath = Path.Combine(dirName, $"{newFileName}{extension}");
                ++f;
            }

            newPath = Path.Combine(dirName, $"{newFileName}{extension}");
            return newPath;
        }
    }

}
