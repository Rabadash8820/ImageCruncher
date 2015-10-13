using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Kernel;
using Kernel.Args;
using GuiShell.Events;

namespace GuiShell.Forms {

    public partial class RollingBallForm : Form, IOperationForm {
        private FileInfo _imgFile;
        private DateTime _start;
        private DateTime _end;

        public RollingBallForm(FileInfo f) {
            InitializeComponent();

            _imgFile = f;

            // Configure progress bar to report percent progress
            MainProgress.Minimum = 0;
            MainProgress.Maximum = 100;
        }

        // INTERFACE
        public event OperationEventHandler OperationStarted;
        public event OperationCompletedEventHandler OperationCompleted;

        // EVENT HANDLERS
        private void ApplyBtn_Click(object sender, EventArgs e) {
            toggleControls(true);

            // Define the arguments to pass the operation
            int winSize = (int)WinSizeUpDown.Value;
            RollingBallArgs args = new RollingBallArgs() {
                Bitmap = Image.FromFile(_imgFile.FullName) as Bitmap,
                WindowSize = winSize
            };

            _start = DateTime.Now;
            OperationWorker.RunWorkerAsync(args);
            OnStarted(winSize);
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            OperationWorker.CancelAsync();
        }
        private void OperationWorker_DoWork(object sender, DoWorkEventArgs e) {
            BackgroundWorker worker = sender as BackgroundWorker;
            ImageCruncher.PerformOperation(
                Operation.RollingBall, e.Argument as RollingBallArgs, worker, e);
        }
        private void OperationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            MainProgress.Value = e.ProgressPercentage;
        }
        private void OperationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            _end = DateTime.Now;

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
        private void OnStarted(int winSize) {
            if (this.OperationStarted == null)
                return;

            Delegate[] subscribers = this.OperationStarted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                OperationEventArgs args = new OperationEventArgs() {
                    Operation = Operation.RollingBall,
                    Args = new RollingBallArgs() { WindowSize = winSize }
                };
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void OnCompleted(Rectangle region) {
            if (this.OperationCompleted == null)
                return;

            Delegate[] subscribers = this.OperationCompleted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                OperationCompletedEventArgs args = new OperationCompletedEventArgs() {
                    Duration = _end.Subtract(_start),
                    Operation = Operation.RollingBall,
                    Result = region
                };
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void toggleControls(bool running) {
            WinSizeUpDown.Enabled = !running;
            ExecuteBtn.Enabled = !running;
            CancelBtn.Enabled = running;
        }

        private void ColorBtn_Click(object sender, EventArgs e) {
            ColorDialog.ShowDialog();
        }
    }

}
