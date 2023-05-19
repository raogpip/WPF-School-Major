using Diploma.EntityFramework;
using Diploma.EntityFramework.Services.NotebookProviders;
using Diploma.EntityFramework.Services.NoteProviders;
using Diploma.WPF.State.Navigators;
using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public static INotebookService notebookService = new DatabaseNotebookService(new SchoolDbContextFactory());
        public static INoteService noteService = new DatabaseNoteService(new SchoolDbContextFactory());

        private INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
            _navigator = navigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is string)
            {
                var viewType = (string)parameter;
                switch (viewType)
                {
                    case "Schedule":
                        _navigator.CurrentViewModel = new ScheduleViewModel(new SchoolDbContextFactory());
                        break;
                    case "Attendance":
                        _navigator.CurrentViewModel = new AttendanceViewModel();
                        break;
                    case "Information":
                        _navigator.CurrentViewModel = new InformationViewModel();
                        break;
                    case "GradesStats":
                        _navigator.CurrentViewModel = new GradesStatsViewModel();
                        break;
                    case "Profile":
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case "Evernote":
                        _navigator.CurrentViewModel = new EvernoteViewModel(notebookService, noteService);
                        break;
                }
            }
        }
    }
}
