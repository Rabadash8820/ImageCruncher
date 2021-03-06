﻿using System;
using System.IO;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

using Kernel;
using Kernel.Args;
using GuiShell.Events;
using GuiShell.Properties;

namespace GuiShell.Forms {

    public partial class MainForm : Form {
        // ENCAPSULATED FIELDS
        private BindingSource _imageBS;
        private Rectangle? _rollingBallRegion;
        private Color _rollingBallColor;
        private const float PEN_WIDTH = 5f;

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
                using (Pen p = new Pen(_rollingBallColor, PEN_WIDTH)) {
                    e.Graphics.DrawRectangle(p, region);
                }
            }
        }
        private void ClearImgBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            ImgPicBox.Refresh();
        }
        private void CloseFileBtn_Click(object sender, EventArgs e) {
            clearOrnaments();
            changeImage(null);
        }

        private void WatercolorBtn_Click(object sender, EventArgs e) {
            WatercolorForm form = new WatercolorForm(_imageBS.DataSource as FileInfo);
            form.FilterStarted += FilterForm_FilterStarted;
            form.FilterCompleted += FilterForm_FilterCompleted;
            form.ShowDialog();
        }
        private void FilterForm_FilterStarted(object sender, FilterEventArgs e) {
            log("--------------------------------------------------------------------------------------------------------");

            // Define a log message based on the type of Operation that's been started
            string msg = "";
            switch (e.Filter) {
                case Filter.Watercolor:
                    msg = String.Format(Resources.WatercolorStartMsg, (e.Args as WatercolorArgs).WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Log that message
            log(msg);
        }
        private void FilterForm_FilterCompleted(object sender, FilterCompletedEventArgs e) {
            string msg = "";
            CompletionState state = e.State;
            string dur = e.Duration.TotalSeconds.ToString("N2");

            // If there was an error...
            if (state == CompletionState.Error)
                log(String.Format(Resources.FilterErrorMsg, dur, Resources.SecondsStr));

            // If filter was cancelled...
            else if (state == CompletionState.Cancelled)
                log(String.Format(Resources.FilterCancelledMsg, dur, Resources.SecondsStr));

            // If filter finished successfully...
            else if (state == CompletionState.Finished) {
                // Define a log message based on the type of Operation that's been started
                switch (e.Filter) {
                    // Draw the rectangle generated by RollingBall
                    case Filter.Watercolor:
                        msg = String.Format(Resources.WatercolorEndMsg, dur, Resources.SecondsStr);
                        break;

                    default:
                        throw new NotImplementedException();
                }

                // Log that message and reset the bound image
                log(msg);
                clearOrnaments();
                changeImage(e.FileInfo);
            }
        }

        private void RollingBallBtn_Click(object sender, EventArgs e) {
            RollingBallForm form = new RollingBallForm(_imageBS.DataSource as FileInfo);
            form.OperationStarted += OperationForm_OperationStarted;
            form.OperationCompleted += OperationForm_OperationCompleted;
            form.ShowDialog();
        }
        private void OperationForm_OperationStarted(object sender, OperationEventArgs e) {
            log("--------------------------------------------------------------------------------------------------------");

            // Define a log message based on the type of Operation that's been started
            string msg = "";
            switch (e.Operation) {
                case Operation.RollingBall:
                    msg = String.Format(Resources.RollingBallStartMsg, (e.Args as RollingBallArgs).WindowSize);
                    break;

                default:
                    throw new NotImplementedException();
            }

            // Log that message
            log(msg);
        }
        private void OperationForm_OperationCompleted(object sender, OperationCompletedEventArgs e) {
            string msg = "";
            CompletionState state = e.State;
            string dur = e.Duration.TotalSeconds.ToString("N2");

            // If there was an error...
            if (state == CompletionState.Error)
                log(String.Format(Resources.OperationErrorMsg, dur, Resources.SecondsStr));

            // If filter was cancelled...
            else if (state == CompletionState.Cancelled)
                log(String.Format(Resources.OperationCancelledMsg, dur, Resources.SecondsStr));

            // If filter finished successfully...
            else if (state == CompletionState.Finished) {
                switch (e.Operation) {
                    // Draw the rectangle generated by RollingBall
                    case Operation.RollingBall:
                        Rectangle region = (Rectangle)e.Result;
                        _rollingBallRegion = region;
                        _rollingBallColor = (e.Args as RollingBallArgs).OptimalColor;
                        ImgPicBox.Refresh();
                        msg = String.Format(Resources.RollingBallEndMsg, dur, Resources.SecondsStr);
                        log(msg);
                        msg = String.Format(Resources.RollingBallOutputMsg, region, (e.Args as RollingBallArgs).OptimalColor);
                        log(msg);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
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
        }
        private void removeDataBindings() {
            ImgTxt.DataBindings.Clear();
            ImgPicBox.DataBindings.Clear();

            _imageBS.DataSource = null;
        }
        private void enableImageControls(bool imageOpen) {
            MainToolStrip.Enabled = imageOpen;
            ClearImgBtn.Enabled = imageOpen;
            CloseFileBtn.Enabled = imageOpen;
        }
        private void tearDownImage() {
            ImgPicBox.Image.Dispose();
            ImgPicBox.Image = null;
            ImgTxt.Text = "";
        }
        private void clearOrnaments() {
            _rollingBallRegion = null;

            log(String.Format(Resources.ImgClearedMsg));
        }
        private void changeImage(FileInfo imageFile) {
            if (imageFile != null) {
                enableImageControls(true);
                addDataBindings(imageFile);
                clearOrnaments();
                Bitmap bmp = Image.FromStream(imageFile.OpenRead()) as Bitmap;
                log(String.Format(Resources.ImgSetMsg, imageFile.FullName, bmp.Width, bmp.Height));
            }
            else {
                enableImageControls(false);
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
            LogListbox.Items.Add(msg);
            LogListbox.TopIndex = LogListbox.Items.Count - 1;
        }
    }

}
