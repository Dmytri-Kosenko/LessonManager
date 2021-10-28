using System;

namespace ViewModel.Commands
{
    public interface IErrorCancelHandler : IErrorHandler
    {
        void HandleCancel(OperationCanceledException ex);
    }
}
