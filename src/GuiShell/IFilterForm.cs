using System;

using GuiShell.Events;

namespace GuiShell {

    internal interface IFilterForm {
        event FilterEventHandler FilterStarted;
        event FilterCompletedEventHandler FilterCompleted;
    }

}
