using System;
using System.Drawing;
using System.Windows.Forms;

namespace GuiShell {

    public partial class RollingBallForm : Form {
        public RollingBallForm() {
            InitializeComponent();
        }
        
        // INTERFACE
        public class RollingBallArgs : EventArgs{
            public Rectangle OptimalRegion;
        }
        public delegate void RollingBallEventHandler(object sender, RollingBallArgs e);
        public event RollingBallEventHandler RollingBallCompleted;

        private void ApplyBtn_Click(object sender, EventArgs e) {
            int winSize = (int)WinSizeUpDown.Value;
            Rectangle optimalRegion = Program.ImageWrapper.RollingBall(winSize);
            
            OnRollingBallCompleted(optimalRegion);

            this.Close();
        }

        // HELPER FUNCTIONS
        private void OnRollingBallCompleted(Rectangle region) {
            if (this.RollingBallCompleted == null)
                return;

            Delegate[] subscribers = this.RollingBallCompleted.GetInvocationList();
            foreach (Delegate subscriber in subscribers) {
                Control c = subscriber.Target as Control;
                RollingBallArgs args = new RollingBallArgs() { OptimalRegion = region };
                if (c != null && c.InvokeRequired)
                    c.BeginInvoke(subscriber, this, args);
                else
                    subscriber.DynamicInvoke(this, args);
            }
        }
    }

}
