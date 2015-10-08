using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Kernel;
using GuiShell.Events;

namespace GuiShell.Forms {

    public partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        private BindingSource _imageBS;
        private Rectangle? _rollingBallRegion;

        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();

            _imageBS = new BindingSource(new ImageWrapper(), null);
            
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
            changeImage(new ImageWrapper(filePath));
        }
        private void ImgPicBox_Paint(object sender, PaintEventArgs e) {
            if (_rollingBallRegion.HasValue) {
                Rectangle region = adjustedOrnament(_rollingBallRegion.Value);
                e.Graphics.DrawRectangle(Pens.Red, region);
            }
        }
        private void WatercolorBtn_Click(object sender, EventArgs e) {
            WatercolorForm form = new WatercolorForm(_imageBS.DataSource as ImageWrapper);
            form.WatercolorCompleted += WatercolorForm_WatercolorCompleted;
            form.ShowDialog();
        }
        private void WatercolorForm_WatercolorCompleted(object sender, WatercolorCompletedEventArgs e) {
            clearOrnaments();
            changeImage(e.ImageWrapper);
        }
        private void RollingBallBtn_Click(object sender, EventArgs e) {
            RollingBallForm form = new RollingBallForm(_imageBS.DataSource as ImageWrapper);
            form.RollingBallCompleted += RollingBallForm_RollingBallCompleted;
            form.ShowDialog();
        }
        private void RollingBallForm_RollingBallCompleted(object sender, RollingBallCompletedEventArgs e) {
            _rollingBallRegion = e.OptimalRegion;
            ImgPicBox.Refresh();
            string msg = $"Optimal region is the rectangle {e.OptimalRegion}.";
            log(msg);
        }
        private void ClearImgBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            ImgPicBox.Refresh();
        }
        private void CloseFileBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            changeImage(new ImageWrapper());
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

            log("Image cleared.");
        }
        private void changeImage(ImageWrapper img) {
            ImageWrapper currImg = _imageBS.DataSource as ImageWrapper;
            _imageBS.DataSource = img;

            string msg = (img.FilePath != null) ? $"Image set to {img.FilePath}." : "Image closed.";
            log(msg);
        }
        private Rectangle adjustedOrnament(Rectangle region) {
            // Reposition/resize the provided Rectangle to match the PictureBox image
            Rectangle imgRect = imageRectangle();
            float ratio = (float)imgRect.Height / (float)ImgPicBox.Image.Height;
            region.X = imgRect.X + (int)(region.X * ratio);
            region.Y = imgRect.Y + (int)(region.Y * ratio);
            region.Width = (int)(region.Width * ratio);
            region.Height = (int)(region.Height * ratio);

            return region;
        }
        private Rectangle imageRectangle() {
            // Code basically copies what PictureBox already does (see PictureBox.ImageRectangleFromSizeMode reference at http://referencesource.microsoft.com/)
            Rectangle c = ImgPicBox.ClientRectangle;
            Rectangle result = new Rectangle();
            Size i = ImgPicBox.Image.Size;
            float ratio = Math.Min((float)c.Width / (float)i.Width, (float)c.Height / (float)i.Height);
            result.Width = (int)(i.Width * ratio);
            result.Height = (int)(i.Height * ratio);
            result.X = (c.Width - result.Width) / 2;
            result.Y = (c.Height - result.Height) / 2;

            return result;
        }
        private void log(object msgObject) {
            // Display the current date and time, followed by the provided data
            DateTime now = DateTime.Now;
            string msg = $"{now.ToShortDateString()} {now.ToLongTimeString()}>  {msgObject}";
            OutputListbox.Items.Add(msg);
            OutputListbox.TopIndex = OutputListbox.Items.Count - 1;
        }

    }

}
