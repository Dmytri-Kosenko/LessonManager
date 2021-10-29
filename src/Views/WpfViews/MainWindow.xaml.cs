using System.Windows;
using ViewModel.Commands;
using ViewModels;

namespace WpfViews
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (DataContext is MainViewModel model)
            {
                model.ErrorHandler = new ErrorHandler();
            }
        }
    }
}
