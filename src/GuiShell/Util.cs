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
        static Util() {

        }

        // HELPER FUNCTIONS
        public static string newFilePath(string oldFilePath, string appendToName) {
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
