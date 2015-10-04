using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Kernel;

namespace GuiShell {

    public partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        BindingSource _imageBS;

        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();

            _imageBS = new BindingSource(Program.ImageWrapper, null);
            
            setDataBindings();
        }

        // EVENT HANDLERS
        private void ImgFileDialog1_FileOk(object sender, CancelEventArgs e) {
            // Reset the private BindingSource
            string filePath = ImgFileDialog.FileName;
            _imageBS.DataSource = new ImageWrapper(filePath);
        }
        private void ImgBrowseBtn_Click(object sender, EventArgs e) {
            ImgFileDialog.ShowDialog();
        }
        private void WatercolorBtn_Click(object sender, EventArgs e) {
            WatercolorForm form = new WatercolorForm();
            form.ShowDialog();
        }
        private void RollingBallBtn_Click(object sender, EventArgs e) {

        }
        private void textBinding_Format(object sender, ConvertEventArgs e) {
            string filePath = e.Value as string;
            e.Value = Path.GetFileName(filePath);
        }
        private void selectedBinding_Format(object sender, ConvertEventArgs e) {
            string filePath = e.Value as string;
            e.Value = (filePath != null);
        }

        // HELPER FUNCTIONS
        private void setDataBindings() {
            // Bind TextBox to the image's filename
            Binding textBinding = new Binding(
                "Text",
                _imageBS,
                Util.GetPropertyName((ImageWrapper i) => i.FilePath),
                true,
                DataSourceUpdateMode.Never);
            textBinding.Format += textBinding_Format;
            ImgTxt.DataBindings.Add(textBinding);

            // Bind PictureBox to the image itself
            Binding picBinding = new Binding(
                "Image",
                _imageBS,
                Util.GetPropertyName((ImageWrapper i) => i.BitmapImage),
                true,
                DataSourceUpdateMode.Never,
                new Bitmap(1, 1));
            ImgPicBox.DataBindings.Add(picBinding);

            // Bind buttons to whether or not an image file has been selected
            Binding toolstripBinding = new Binding(
                "Enabled",
                _imageBS,
                Util.GetPropertyName((ImageWrapper i) => i.FilePath),
                true,
                DataSourceUpdateMode.Never);
            Binding closeBtnBinding = new Binding(
                "Enabled",
                _imageBS,
                Util.GetPropertyName((ImageWrapper i) => i.FilePath),
                true,
                DataSourceUpdateMode.Never);
            toolstripBinding.Format += selectedBinding_Format;
            closeBtnBinding.Format += selectedBinding_Format;
            MainToolStrip.DataBindings.Add(toolstripBinding);
            CloseFileBtn.DataBindings.Add(closeBtnBinding);
        }

        private void CloseFileBtn_Click(object sender, EventArgs e) {
            _imageBS.DataSource = new ImageWrapper();
        }
        
    }

}
