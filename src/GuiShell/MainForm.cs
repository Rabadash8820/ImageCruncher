using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Kernel;

namespace GuiShell {

    public partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        private BindingSource _imageBS;
        private Rectangle? _rollingBallRegion;

        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();

            _imageBS = new BindingSource(Program.ImageWrapper, null);
            
            setDataBindings();
        }

        // EVENT HANDLERS
        private void FileNameBinding_Format(object sender, ConvertEventArgs e) {
            string filePath = e.Value as string;
            e.Value = Path.GetFileName(filePath);
        }
        private void EnabledPropertyBinding_Format(object sender, ConvertEventArgs e) {
            string filePath = e.Value as string;
            e.Value = (filePath != null);
        }
        private void ImgBrowseBtn_Click(object sender, EventArgs e) {
            ImgFileDialog.ShowDialog();
        }
        private void ImgFileDialog_FileOk(object sender, CancelEventArgs e) {
            // Reset the private BindingSource
            string filePath = ImgFileDialog.FileName;
            _imageBS.DataSource = new ImageWrapper(filePath);
        }
        private void ImgPicBox_Paint(object sender, PaintEventArgs e) {
            if (_rollingBallRegion.HasValue) {
                using (Pen pen = new Pen(Color.Red, 2)) {
                    e.Graphics.DrawRectangle(pen, _rollingBallRegion.Value);
                }
            }
        }
        private void WatercolorBtn_Click(object sender, EventArgs e) {
            WatercolorForm form = new WatercolorForm();
            form.ShowDialog();
        }
        private void RollingBallBtn_Click(object sender, EventArgs e) {
            RollingBallForm form = new RollingBallForm();
            form.RollingBallCompleted += RollingBallForm_RollingBallCompleted;
            form.ShowDialog();
        }
        private void RollingBallForm_RollingBallCompleted(object sender, RollingBallForm.RollingBallArgs e) {
            _rollingBallRegion = e.OptimalRegion;
            ImgPicBox.Refresh();
        }
        private void ClearImgBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            ImgPicBox.Refresh();
        }
        private void CloseFileBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            _imageBS.DataSource = new ImageWrapper();
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
            textBinding.Format += FileNameBinding_Format;
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
            MainToolStrip.DataBindings.Add(enabledPropertyBinding());
            CloseFileBtn.DataBindings.Add(enabledPropertyBinding());
            ClearImgBtn.DataBindings.Add(enabledPropertyBinding());
        }
        private Binding enabledPropertyBinding() {
            Binding b = new Binding(
                "Enabled",
                _imageBS,
                Util.GetPropertyName((ImageWrapper i) => i.FilePath),
                true,
                DataSourceUpdateMode.Never);
            b.Format += EnabledPropertyBinding_Format;
            return b;
        }
        private void clearOrnaments() {
            _rollingBallRegion = null;
        }
        
    }

}
