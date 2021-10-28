using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel.Commands.AsyncCommands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync();
        bool CanExecute();
    }
}
