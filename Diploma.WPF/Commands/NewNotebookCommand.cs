using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.Commands
{
    public class NewNotebookCommand : ICommand
    {
        public EvernoteViewModel VM { get; set; }
        public event EventHandler? CanExecuteChanged;

        public NewNotebookCommand(EvernoteViewModel vm)
        {
            VM = vm;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            VM.CreateNotebook();
        }
    }
}
