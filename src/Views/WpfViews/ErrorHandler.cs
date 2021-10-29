using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel.Commands;

namespace WpfViews
{
    public class ErrorHandler : IErrorHandler
    {
        public void HandleError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
