using System;

using Kernel;
using Kernel.Args;

namespace GuiShell.Events {

    public class OperationEventArgs : EventArgs {
        public Operation Operation { get; set; }
        public ImageArgs Args { get; set; }
    }
    public delegate void OperationEventHandler(object sender, OperationEventArgs e);

}
