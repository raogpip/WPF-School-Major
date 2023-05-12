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
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                switch (viewType)
                {
                    case ViewType.Schedule:
                        _navigator.CurrentViewModel = new ScheduleViewModel();
                        break;
                    case ViewType.Attendance:
                        _navigator.CurrentViewModel = new AttendanceViewModel();
                        break;
                    case ViewType.Information:
                        _navigator.CurrentViewModel = new InformationViewModel();
                        break;
                    case ViewType.GradesStats:
                        _navigator.CurrentViewModel = new GradesStatsViewModel();
                        break;
                    case ViewType.Profile:
                        _navigator.CurrentViewModel = new ProfileViewModel();
                        break;
                    case ViewType.Evernote:
                        _navigator.CurrentViewModel = new EvernoteViewModel();
                        break;
                }
            }
        }
    }
}
