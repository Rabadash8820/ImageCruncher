using System;
using System.Windows.Forms;

using Kernel;

namespace GuiShell {

    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ImageWrapper = new ImageWrapper();

            Application.Run(new MainForm());
        }

        public static ImageWrapper ImageWrapper { get; private set; }

    }

}
