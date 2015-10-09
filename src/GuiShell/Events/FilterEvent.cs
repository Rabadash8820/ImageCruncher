using System;

using Kernel;
using Kernel.Args;

namespace GuiShell.Events {

    public class FilterEventArgs : EventArgs {
        public Filter Filter { get; set; }
        public ImageArgs Args { get; set; }
    }
    public delegate void FilterEventHandler(object sender, FilterEventArgs e);

}
