using System;
using System.Drawing;

namespace GuiShell.Events {

    public class RollingBallCompletedEventArgs : EventArgs {
        public Rectangle OptimalRegion;
    }
    public delegate void RollingBallCompletedEventHandler(object sender, RollingBallCompletedEventArgs e);

}
