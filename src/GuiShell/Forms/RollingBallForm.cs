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
        private const int DEFAULT_WIN_FACTOR = 10;

        public RollingBallForm(FileInfo f) {
            InitializeComponent();

            _imgFile = f;

            // Configure progress bar to report percent progress
            MainProgress.Minimum = 0;
            MainProgress.Maximum = 100;

            // Initialize window size controls
            int defaultOddSize = nearestOdd(defaultWindowSize(f));
            WinSizeUpDown.Maximum = 2 * defaultOddSize - 1;     // 2 * odd - 1 = odd
            WinSizeUpDown.Value = defaultOddSize;

            // Initialize color controls
            adjustCurrentColor();
            RedValueLbl.DataBindings.Add("Text", RedTrack, "Value");
            GreenValueLbl.DataBindings.Add("Text", GreenTrack, "Value");
            BlueValueLbl.DataBindings.Add("Text", BlueTrack, "Value");
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
                OptimalColor = ColorDrawLbl.BackColor
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
        private void RedTrack_Scroll(object sender, EventArgs e) {
            adjustCurrentColor();
        }
        private void GreenTrack_Scroll(object sender, EventArgs e) {
            adjustCurrentColor();
        }
        private void BlueTrack_Scroll(object sender, EventArgs e) {
            adjustCurrentColor();
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
                    OptimalColor = ColorDrawLbl.BackColor,
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
            ColorGroup.Enabled = !running;
        }
        private void adjustCurrentColor() {
            int r = (int)RedTrack.Value;
            int g = (int)GreenTrack.Value;
            int b = (int)BlueTrack.Value;
            ColorDrawLbl.BackColor = Color.FromArgb(r, g, b);
        }
        private int defaultWindowSize(FileInfo f) {
            Bitmap bmp = Image.FromFile(f.FullName) as Bitmap;
            int minDim = Math.Min(bmp.Width, bmp.Height);
            return minDim / DEFAULT_WIN_FACTOR;
        }
        private int nearestOdd(double value) {
            double truncated = Math.Truncate(value * 10.0) / 10.0;
            return (int)Math.Round(truncated, 0, MidpointRounding.ToEven) - 1;
        }
        private decimal clamp(decimal value, decimal min, decimal max) {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }

    }

}
