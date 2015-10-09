using System;

using GuiShell.Events;

namespace GuiShell {

    internal interface IOperationForm {
        event OperationEventHandler OperationStarted;
        event OperationCompletedEventHandler OperationCompleted;
    }

}
