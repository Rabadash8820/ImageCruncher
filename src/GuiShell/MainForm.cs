using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.ComponentModel;
using System.Windows.Forms;

using Kernel;

namespace GuiShell {

    public partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        ImageWrapper _image;

        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();

            _image = new ImageWrapper();
        }

        // EVENT HANDLERS
        private void ImgFileDialog1_FileOk(object sender, CancelEventArgs e) {
            string filePath = ImgFileDialog.FileName;
            
            // Reset the private ImageWrapper
            _image.FilePath = filePath;

            // Show the image's name in the TextBox
            string fileName = Path.GetFileName(filePath);
            ImgTxt.Text = fileName;

            // Display the actual image in the PictureBox
            ImgPicBox.Image = new Bitmap(filePath);
        }
        private void ImgBrowseBtn_Click(object sender, EventArgs e) {
            ImgFileDialog.ShowDialog();
        }
        private void WatercolorBtn_Click(object sender, EventArgs e) {

        }
        private void RollingBallBtn_Click(object sender, EventArgs e) {

        }
    }

}
