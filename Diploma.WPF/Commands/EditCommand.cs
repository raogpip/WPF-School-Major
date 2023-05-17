using Diploma.EntityFramework.Services.NotebookProviders;
using Diploma.EntityFramework.Services.NoteProviders;
using Diploma.EntityFramework;
using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.Commands
{
    public class EditCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public EvernoteViewModel ViewModel;

        public EditCommand(EvernoteViewModel vm)
        {
            ViewModel = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            ViewModel.StartEditing();
        }
    }
}
