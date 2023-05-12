using Diploma.Domain.Models;
using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.Commands
{
    public class NewNoteCommand : ICommand
    {
        public EvernoteViewModel VM { get; set; }
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public NewNoteCommand(EvernoteViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;

            return selectedNotebook != null ? true : false;
        }

        public void Execute(object? parameter)
        {
            Notebook selectedNotebook = parameter as Notebook;
            VM.CreateNote(selectedNotebook.Id);
        }
    }
}
