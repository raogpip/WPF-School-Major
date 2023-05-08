using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.State.Navigators
{
    public enum ViewType
    {
        Schedule,
        Attendance,
        Information,
        GradesStats,
        Profile
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
