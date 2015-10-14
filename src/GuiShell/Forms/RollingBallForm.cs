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
                WindowSize = winSize,
                OptimalColor = Color.Red
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

            // If there was an error...
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message);
                toggleControls(false);
                OnCompleted(default(Rectangle), CompletionState.Error);
            }

            // If the operation was cancelled
            else if (e.Cancelled) {
                toggleControls(false);
                OnCompleted(default(Rectangle), CompletionState.Cancelled);
            }

            // Otherwise, the operation was successful...
            else {
                toggleControls(false);
                Rectangle region = (Rectangle)e.Result;
                OnCompleted(region, CompletionState.Finished);

                this.Close();
            }
        }

        // HELPER FUNCTIONS
        private void OnStarted(int winSize) {
            if (this.OperationStarted == null)
                return;

            // Define EventArgs
            OperationEventArgs args = new OperationEventArgs() {
                Operation = Operation.RollingBall,
                Args = new RollingBallArgs() { WindowSize = winSize }
            };

            // Invoke all currently subscribed event handlers
            Delegate[] subscribers = this.OperationStarted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void OnCompleted(Rectangle region, CompletionState state) {
            if (this.OperationCompleted == null)
                return;

            // Define EventArgs
            OperationCompletedEventArgs args = new OperationCompletedEventArgs() {
                Duration = _end.Subtract(_start),
                Operation = Operation.RollingBall,
                Result = region,
                State = state,
                Args = new RollingBallArgs() {
                    OptimalColor = ColorDialog.Color,
                    WindowSize = (int)WinSizeUpDown.Value,
                    Bitmap = Image.FromFile(_imgFile.FullName) as Bitmap
                }
            };

            // Invoke all currently subscribed event handlers
            Delegate[] subscribers = this.OperationCompleted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
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
