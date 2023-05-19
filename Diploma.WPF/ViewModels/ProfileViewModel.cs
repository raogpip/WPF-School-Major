using Diploma.Domain.Models;
using Diploma.EntityFramework.Services.StudentProviders;
using Diploma.EntityFramework.Services.TeacherProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Diploma.WPF.ViewModels
{
    public class ProfileViewModel : ViewModelBase
    {
		private Account _currentUserAccount;
		private IStudentService studentService;
		private ITeacherService teacherService;

		public Account CurrentUserAccount
		{
			get { return _currentUserAccount; }
			set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
		}

		public ProfileViewModel()
		{
			studentService = new DatabaseStudentService(new EntityFramework.SchoolDbContextFactory());
			teacherService = new DatabaseTeacherService(new EntityFramework.SchoolDbContextFactory());
			LoadCurrentUserData();
		}

        private void LoadCurrentUserData()
        {
			var user = studentService.GetStudentByUsername(Thread.CurrentPrincipal.Identity.Name);
			if(user == null)
			{
				var teacher = teacherService.GetTeacherByUsername(Thread.CurrentPrincipal.Identity.Name);
                CurrentUserAccount = new Account
                {
					Id = teacher.Id,
                    Username = teacher.Username,
					Password = teacher.Password,
                    DisplayName = $"Hello, {teacher.Username} :3"
                };
            }
			else if(user != null)
			{
				CurrentUserAccount = new Account
				{
					Id = user.Id,
					Username = user.Username,
					Password = user.Password,
					DisplayName = $"Hello, {user.Username} :3"
				};
			}
			else
			{
				MessageBox.Show("Invalid user, not logged in");
				Application.Current.Shutdown();
			}
        }
    }
}
