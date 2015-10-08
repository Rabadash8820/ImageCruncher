using System;
using System.IO;

namespace GuiShell.Events {

    public class WatercolorCompletedEventArgs : EventArgs {
        public FileInfo FileInfo;
    }
    public delegate void WatercolorCompletedEventHandler(object sender, WatercolorCompletedEventArgs e);

}
