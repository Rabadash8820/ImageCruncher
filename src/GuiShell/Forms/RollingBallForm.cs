using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Kernel;
using GuiShell.Events;

namespace GuiShell.Forms {

    public partial class RollingBallForm : Form {
        private ImageWrapper _img;

        public RollingBallForm(ImageWrapper img) {
            InitializeComponent();

            _img = img;

            // Configure progress bar to report percent progress
            MainProgress.Minimum = 0;
            MainProgress.Maximum = 100;
        }
        
        // INTERFACE
        public event RollingBallCompletedEventHandler RollingBallCompleted;

        // EVENT HANDLERS
        private void ApplyBtn_Click(object sender, EventArgs e) {
            toggleControls(true);
            int winSize = (int)WinSizeUpDown.Value;
            RollingBallArgs args = new RollingBallArgs() { WindowSize = winSize };
            RollingBallBgw.RunWorkerAsync(args);
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            RollingBallBgw.CancelAsync();
        }
        private void RollingBallBgw_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            _img.PerformOperation(
                Operation.RollingBall, e.Argument, worker, e);
        }
        private void RollingBallBgw_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            MainProgress.Value = e.ProgressPercentage;
        }
        private void RollingBallBgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Error != null)
                MessageBox.Show(e.Error.Message);
            else if (e.Cancelled)
                toggleControls(false);
            else {
                toggleControls(false);
                Rectangle region = (Rectangle)e.Result;
                OnCompleted(region);

                this.Close();
            }
        }

        // HELPER FUNCTIONS
        private void OnCompleted(Rectangle region) {
            if (this.RollingBallCompleted == null)
                return;

            Delegate[] subscribers = this.RollingBallCompleted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                RollingBallCompletedEventArgs args = new RollingBallCompletedEventArgs() { OptimalRegion = region };
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void toggleControls(bool running) {
            WinSizeLbl.Enabled = !running;
            WinSizeUpDown.Enabled = !running;
            ExecuteBtn.Enabled = !running;
            CancelBtn.Enabled = running;
        }
        
    }

}
