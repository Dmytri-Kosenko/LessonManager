using System;

namespace ViewModel.Commands
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
