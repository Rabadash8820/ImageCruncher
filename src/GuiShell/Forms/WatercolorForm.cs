using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Kernel;
using Kernel.Args;
using GuiShell.Events;

namespace GuiShell.Forms {

    public partial class WatercolorForm : Form {
        private FileInfo _imgFile;

        public WatercolorForm(FileInfo file) {
            InitializeComponent();

            _imgFile = file;
        }

        // INTERFACE
        public event WatercolorCompletedEventHandler WatercolorCompleted;

        // EVENT HANDLERS
        private void ApplyBtn_Click(object sender, EventArgs e) {
            toggleControls(true);

            // Define the arguments to pass the filter function
            int winSize = (int)WinSizeUpDown.Value;
            WatercolorArgs args = new WatercolorArgs() {
                Bitmap = Image.FromFile(_imgFile.FullName) as Bitmap,
                WindowSize = winSize
            };

            WatercolorBgw.RunWorkerAsync(args);
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            WatercolorBgw.CancelAsync();
        }
        private void WatercolorBgw_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            ImageCruncher.ApplyFilter(
                Filter.Watercolor, e.Argument as WatercolorArgs, worker, e);
        }
        private void WatercolorBgw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            MainProgress.Value = e.ProgressPercentage;
        }
        private void WatercolorBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message);
                toggleControls(false);
            }
            else if (e.Cancelled)
                toggleControls(false);
            else {
                toggleControls(false);
                Bitmap bmp = e.Result as Bitmap;
                string newPath = Util.newFilePath(_imgFile.FullName, nameof(Filter.Watercolor));
                bmp.Save(newPath);
                OnCompleted(new FileInfo(newPath));

                this.Close();
            }
        }

        // HELPER FUNCTIONS
        private void OnCompleted(FileInfo file) {
            if (this.WatercolorCompleted == null)
                return;

            Delegate[] subscribers = this.WatercolorCompleted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                WatercolorCompletedEventArgs args = new WatercolorCompletedEventArgs() { FileInfo = file };
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void toggleControls(bool running) {
            WinSizeLbl.Enabled = !running;
            WinSizeUpDown.Enabled = !running;
            ApplyBtn.Enabled = !running;
            CancelBtn.Enabled = running;
        }
    }

}
