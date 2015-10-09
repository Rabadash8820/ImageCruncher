using System;

namespace GuiShell.Events {

    public class OperationCompletedEventArgs : OperationEventArgs {
        public object Result { get; set; }
        public TimeSpan Duration { get; set; }
    }
    public delegate void OperationCompletedEventHandler(object sender, OperationCompletedEventArgs e);

}
