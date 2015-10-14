using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Kernel;
using Kernel.Args;
using GuiShell.Events;

namespace GuiShell.Forms {

    public partial class WatercolorForm : Form, IFilterForm {
        private FileInfo _imgFile;
        private DateTime _start;
        private DateTime _end;

        public WatercolorForm(FileInfo file) {
            InitializeComponent();

            _imgFile = file;
        }

        // INTERFACE
        public event FilterEventHandler FilterStarted;
        public event FilterCompletedEventHandler FilterCompleted;

        // EVENT HANDLERS
        private void ApplyBtn_Click(object sender, EventArgs e) {
            toggleControls(true);

            // Define the arguments to pass the filter function
            int winSize = (int)WinSizeUpDown.Value;
            WatercolorArgs args = new WatercolorArgs() {
                Bitmap = Image.FromFile(_imgFile.FullName) as Bitmap,
                WindowSize = winSize
            };

            _start = DateTime.Now;
            FilterWorker.RunWorkerAsync(args);
            OnStarted(winSize);
        }
        private void CancelBtn_Click(object sender, EventArgs e) {
            FilterWorker.CancelAsync();
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
            _end = DateTime.Now;

            // If an error occurred...
            if (e.Error != null) {
                MessageBox.Show(e.Error.Message);
                toggleControls(false);
                OnCompleted(null, CompletionState.Error);
            }

            // If the filter was cancelled...
            else if (e.Cancelled) {
                toggleControls(false);
                OnCompleted(null, CompletionState.Cancelled);
            }

            // Otherwise, the filter was successful...
            else {
                toggleControls(false);
                Bitmap bmp = e.Result as Bitmap;
                string newPath = Util.newFilePath(_imgFile.FullName, nameof(Filter.Watercolor));
                bmp.Save(newPath);
                OnCompleted(new FileInfo(newPath), CompletionState.Finished);

                this.Close();
            }
        }

        // HELPER FUNCTIONS
        private void OnStarted(int winSize) {
            if (this.FilterStarted == null)
                return;

            // Define EventArgs
            FilterEventArgs args = new FilterEventArgs() {
                Filter = Filter.Watercolor,
                Args = new WatercolorArgs() { WindowSize = winSize }
            };

            // Invoke all currently subscribed event handlers
            Delegate[] subscribers = this.FilterStarted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
        private void OnCompleted(FileInfo file, CompletionState state) {
            if (this.FilterCompleted == null)
                return;

            // Define EventArgs
            FilterCompletedEventArgs args = new FilterCompletedEventArgs() {
                Duration = _end.Subtract(_start),
                Filter = Filter.Watercolor,
                FileInfo = file,
                State = state,
                Args = new WatercolorArgs() {
                    Bitmap = Image.FromFile(_imgFile.FullName) as Bitmap,
                    WindowSize = (int)WinSizeUpDown.Value
                }
            };
            
            // Invoke all currently subscribed event handlers
            Delegate[] subscribers = this.FilterCompleted.GetInvocationList();
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
            ApplyBtn.Enabled = !running;
            CancelBtn.Enabled = running;
        }
    }

}
