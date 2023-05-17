using Diploma.WPF.ViewModels;
using System.Windows;

namespace Diploma.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            DataContext = new LoginViewModel();
        }
    }
}
