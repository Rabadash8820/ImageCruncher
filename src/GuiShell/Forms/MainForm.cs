using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Kernel;
using GuiShell.Events;
using GuiShell.Properties;

namespace GuiShell.Forms {

    public partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        private BindingSource _imageBS;
        private Rectangle? _rollingBallRegion;

        // CONSTRUCTOR
        public MainForm() {
            InitializeComponent();

            _imageBS = new BindingSource();
        }

        // EVENT HANDLERS
        private void FileNameBinding_Format(object sender, ConvertEventArgs e) {
            string filePath = e.Value as string;
            e.Value = Path.GetFileName(filePath);
        }
        private void PicBinding_Format(object sender, ConvertEventArgs e) {
            string filePath = e.Value as string;
            e.Value = Bitmap.FromFile(filePath);
        }
        private void ImgBrowseBtn_Click(object sender, EventArgs e) {
            ImgFileDialog.ShowDialog();
        }
        private void ImgFileDialog_FileOk(object sender, CancelEventArgs e) {
            // Reset the private BindingSource
            string filePath = ImgFileDialog.FileName;
            changeImage(new FileInfo(filePath));
        }
        private void ImgPicBox_Paint(object sender, PaintEventArgs e) {
            if (_rollingBallRegion.HasValue) {
                Rectangle region = adjustedOrnament(_rollingBallRegion.Value);
                e.Graphics.DrawRectangle(Pens.Red, region);
            }
        }
        private void WatercolorBtn_Click(object sender, EventArgs e) {
            applyFilter(Filter.Watercolor);
        }
        private void WatercolorForm_WatercolorCompleted(object sender, WatercolorCompletedEventArgs e) {
            clearOrnaments();
            changeImage(e.FileInfo);
        }
        private void RollingBallBtn_Click(object sender, EventArgs e) {
            RollingBallForm form = new RollingBallForm(_imageBS.DataSource as FileInfo);
            form.RollingBallCompleted += RollingBallForm_RollingBallCompleted;
            form.ShowDialog();
        }
        private void RollingBallForm_RollingBallCompleted(object sender, RollingBallCompletedEventArgs e) {
            _rollingBallRegion = e.OptimalRegion;
            ImgPicBox.Refresh();
            string msg = String.Format(Resources.RollingBallOutputMsg, e.OptimalRegion);
            log(msg);
        }
        private void ClearImgBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            ImgPicBox.Refresh();
        }
        private void CloseFileBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            changeImage(null);
        }

        // HELPER FUNCTIONS
        private void addDataBindings(FileInfo imageFile) {
            // Reset the BindingSource, and just return if we've already added the bindings
            bool bound = (_imageBS.DataSource != null);
            _imageBS.DataSource = imageFile;
            if (bound)
                return;

            // Bind TextBox to the image's filename
            Binding textBinding = new Binding(
                "Text",
                _imageBS,
                "Name",
                true,
                DataSourceUpdateMode.Never);
            textBinding.Format += FileNameBinding_Format;
            ImgTxt.DataBindings.Add(textBinding);

            // Bind PictureBox to the image itself
            Binding picBinding = new Binding(
                "Image",
                _imageBS,
                "FullName",
                true,
                DataSourceUpdateMode.Never);
            picBinding.Format += PicBinding_Format;
            ImgPicBox.DataBindings.Add(picBinding);

            // Now we've added bindings...
            bound = true;
        }
        private void removeDataBindings() {
            ImgTxt.DataBindings.Clear();
            ImgPicBox.DataBindings.Clear();

            _imageBS.DataSource = null;
        }
        private void enableControls(bool doIt) {
            MainToolStrip.Enabled = doIt;
            ClearImgBtn.Enabled = doIt;
            CloseFileBtn.Enabled = doIt;
        }
        private void tearDownImage() {
            ImgPicBox.Image.Dispose();
            ImgPicBox.Image = null;
            ImgTxt.Text = "";
        }
        private void applyFilter(Filter filter) {
            // Release the handle on the currently open image
            //changeImage(null);

            // Define the appropriate form and subscribe to any events
            Form form;
            switch (filter) {
                case Filter.Watercolor:
                    form = new WatercolorForm(_imageBS.DataSource as FileInfo);
                    (form as WatercolorForm).WatercolorCompleted += WatercolorForm_WatercolorCompleted;
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Show the form
            form.ShowDialog();
        }
        private void clearOrnaments() {
            _rollingBallRegion = null;

            log(String.Format(Resources.ImgClearedMsg));
        }
        private void changeImage(FileInfo imageFile) {
            if (imageFile != null) {
                enableControls(true);
                addDataBindings(imageFile);
                log(String.Format(Resources.ImgSetMsg, imageFile.FullName));
            }
            else {
                enableControls(false);
                removeDataBindings();
                tearDownImage();
                log(String.Format(Resources.ImgClosedMsg));
            }
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
