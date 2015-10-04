using System;
using System.Windows.Forms;
using System.ComponentModel;

using Kernel;
using GuiShell.Events;

namespace GuiShell.Forms {

    public partial class WatercolorForm : Form {
        public WatercolorForm() {
            InitializeComponent();
        }

        // INTERFACE
        public event WatercolorCompletedEventHandler WatercolorCompleted;

        // EVENT HANDLERS
        private void ApplyBtn_Click(object sender, EventArgs e) {
            toggleControls(true);
            int winSize = (int)WinSizeUpDown.Value;
            bool save = CopyChk.Checked;
            WatercolorArgs args = new WatercolorArgs() {
                WindowSize = winSize,
                SaveUnfiltered = save
            };
            WatercolorBgw.RunWorkerAsync(args);
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            WatercolorBgw.CancelAsync();
        }
        private void WatercolorBgw_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            Program.ImageWrapper.ApplyFilter(
                Filter.Watercolor, e.Argument, worker, e);
        }
        private void WatercolorBgw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            MainProgress.Value = e.ProgressPercentage;
        }
        private void WatercolorBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else if (e.Cancelled)
                toggleControls(false);
            else {
                toggleControls(false);
                ImageWrapper img = (ImageWrapper)e.Result;
                OnCompleted(img);

                this.Close();
            }
        }

        // HELPER FUNCTIONS
        private void OnCompleted(ImageWrapper img) {
            if (this.WatercolorCompleted == null)
                return;

            Delegate[] subscribers = this.WatercolorCompleted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                WatercolorCompletedEventArgs args = new WatercolorCompletedEventArgs() { ImageWrapper = img};
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void toggleControls(bool running) {
            WinSizeLbl.Enabled = !running;
            WinSizeUpDown.Enabled = !running;
            CopyLbl.Enabled = !running;
            CopyChk.Enabled = !running;
            ApplyBtn.Enabled = !running;
            CancelBtn.Enabled = running;
        }
    }

}
