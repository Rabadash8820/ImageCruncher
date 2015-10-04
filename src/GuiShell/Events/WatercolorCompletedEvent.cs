using System;
using System.Drawing;

using Kernel;

namespace GuiShell.Events {

    public class WatercolorCompletedEventArgs : EventArgs {
        public ImageWrapper ImageWrapper;
    }
    public delegate void WatercolorCompletedEventHandler(object sender, WatercolorCompletedEventArgs e);

}
