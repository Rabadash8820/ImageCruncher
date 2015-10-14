using System;
using System.IO;

namespace GuiShell.Events {

    public class FilterCompletedEventArgs : FilterEventArgs {
        public FileInfo FileInfo { get; set; }
        public TimeSpan Duration { get; set; }
        public CompletionState State { get; set; }
    }
    public delegate void FilterCompletedEventHandler(object sender, FilterCompletedEventArgs e);

}
