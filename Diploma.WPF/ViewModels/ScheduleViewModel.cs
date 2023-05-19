using Diploma.Domain.Models;
using Diploma.EntityFramework;
using Diploma.EntityFramework.Services.StudentProviders;
using Diploma.EntityFramework.Services.TeacherProviders;
using Microsoft.CognitiveServices.Speech.Transcription;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Diploma.WPF.ViewModels
{
    public class ScheduleViewModel : ViewModelBase
    {
        private readonly SchoolDbContextFactory _dbContextFactory;
		private DateTime selectedDate;
        private Account _currentUserAccount;
        private IStudentService studentService;
        private ITeacherService teacherService;

        public Account CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }

        public DateTime SelectedDate
		{
			get { return selectedDate; }
			set { selectedDate = value; OnPropertyChanged(nameof(SelectedDate)); GetLectures(); }
		}
        

        public ObservableCollection<Lecture> Lectures { get; set; }

        public ScheduleViewModel(SchoolDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            studentService = new DatabaseStudentService(new SchoolDbContextFactory());
            teacherService = new DatabaseTeacherService(new SchoolDbContextFactory());
            Lectures = new ObservableCollection<Lecture>();    
            GetCurrentUser();
        }

        private void GetCurrentUser()
        {
            var student = studentService.GetStudentByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(student == null)
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
            else if(student != null)
            {
                CurrentUserAccount = new Account
                {
                    Id = student.Id,
                    Username = student.Username,
                    Password = student.Password,
                    DisplayName = $"Hello, {student.Username} :3"
                };
            }
            else
            {
                MessageBox.Show("Invalid user, not logged in");
                Application.Current.Shutdown();
            }
        }
        
        private void GetLectures()
        {
            using(SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {

                //шось таке
                //select all lectures from table Lectures join Student_Lectures where Student.Id = CurrentUserAccout.Id
                //var lectures = from lect in dbContext.Lectures
                //              from stuLect in dbContext.Student_Lectures
                //              where lect.Id == stuLect.LectureId && stuLect.StudentId == CurrentUserAccount.Id && lect.Date == SelectedDate
                //              select new Lecture()
                //              {
                //                  Id = stuLect.LectureId,
                //                  SubjectId = lect.SubjectId,
                //                  TeacherId = lect.TeacherId,
                //                  Date = lect.Date,
                //                  AudienceNumber = lect.AudienceNumber
                //              };

                var lectures = from l in dbContext.Lectures
                               join sl in dbContext.Student_Lectures on l.Id equals sl.LectureId
                               where sl.StudentId == CurrentUserAccount.Id && l.Date == DateOnly.FromDateTime(SelectedDate)
                               select l;

                Lectures.Clear();
                foreach (var lecture in lectures)
                {
                    Lectures.Add(lecture);
                }
            }
           
        }
    }
}
