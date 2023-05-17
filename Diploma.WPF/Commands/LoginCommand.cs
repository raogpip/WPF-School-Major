using Diploma.WPF.ViewModels;
using System;
using System.Windows.Input;

namespace Diploma.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public LoginViewModel _viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return (string.IsNullOrWhiteSpace(_viewModel.Username) || _viewModel.Username.Length < 3
                || _viewModel.Password == null || _viewModel.Password.Length < 3) ? true : false;
        }

        public void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }
    }
}
