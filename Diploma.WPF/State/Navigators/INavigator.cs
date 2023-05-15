using Diploma.WPF.ViewModels;
using System.Windows.Input;

namespace Diploma.WPF.State.Navigators
{
    public enum ViewType
    {
        Schedule,
        Attendance,
        Information,
        GradesStats,
        Evernote,
        Profile
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
