using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands.AsyncCommands
{
    public class AsyncCommand<T> : AsyncCommandBase, IAsyncCommand<T>
    {
        private readonly Func<T?, CancellationToken?, Task> _execute;
        private readonly Predicate<T?>? _canExecute;

        public AsyncCommand(
            Func<T?, CancellationToken?, Task> execute,
            CancellationTokenSource? cancel = null,
            Predicate<T?>? canExecute = null,
            IErrorCancelHandler? errorHandler = null)
            : base(errorHandler, cancel, true)
        {
            _execute = (p, _) => execute.Invoke(p, CancellationSource?.Token);
            _canExecute = canExecute;
        }

        public AsyncCommand(Func<T?, Task> execute,
            Predicate<T?>? canExecute = null,
            IErrorHandler? errorHandler = null)
            : base(errorHandler, null, false)
        {
            _execute = (p, _) => execute.Invoke(p);
            _canExecute = canExecute;
        }

        public bool CanExecute(T? parameter) =>
            !IsExecuting &&
            (_canExecute?.Invoke(parameter) ?? true) &&
            (!CancellationSource?.IsCancellationRequested ?? true);

        public async Task ExecuteAsync(T? parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    IsExecuting = true;
                    await _execute.Invoke(parameter, CancellationSource?.Token);
                }
                finally
                {
                    IsExecuting = false;
                }
            }
            RaiseCanExecuteChanged();
        }

        #region Explicit implementations
        bool ICommand.CanExecute(object? parameter) => CanExecute((T?)parameter);

        void ICommand.Execute(object? parameter) =>
            ExecuteAsync((T?) parameter)
                .FireAndForgetSafeAsync(ErrorCancelHandler);
        #endregion
    }
}
