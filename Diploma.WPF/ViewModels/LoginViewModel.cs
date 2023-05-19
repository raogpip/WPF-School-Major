using Diploma.EntityFramework.Services.StudentProviders;
using Diploma.WPF.Commands;
using System.Windows.Input;

namespace Diploma.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        //-> Fields

        private string username = "vitalik";
        private string password = "vitalik";
        private string errorMessage;
        private bool isViewVisible = true;
        private IStudentService studentService;
        private bool buttonStudentIsChecked = true;
        private bool buttonTeacherIsChecked;

        //

        //-> Properties

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(nameof(Password)); }
        }

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
        }

        public bool IsViewVisible
        {
            get { return isViewVisible; }
            set { isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); }
        }

        public bool ButtonTeacherIsChecked
        {
            get { return buttonTeacherIsChecked; }
            set { buttonTeacherIsChecked = value; OnPropertyChanged(nameof(ButtonTeacherIsChecked)); if (value) ButtonStudentIsChecked = false; }
        }

        public bool ButtonStudentIsChecked
        {
            get { return buttonStudentIsChecked; }
            set { buttonStudentIsChecked = value; OnPropertyChanged(nameof(ButtonStudentIsChecked)); if (value) ButtonTeacherIsChecked = false; }
        }


        //

        //-> Commands

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            studentService = new DatabaseStudentService(new EntityFramework.SchoolDbContextFactory());
            LoginCommand = new LoginCommand(this);
        }



    }
}
