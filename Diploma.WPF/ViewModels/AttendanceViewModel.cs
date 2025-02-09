using Diploma.Domain.Models;
using Diploma.EntityFramework;
using Diploma.EntityFramework.Services.StudentProviders;
using Diploma.EntityFramework.Services.TeacherProviders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Diploma.WPF.ViewModels
{
    public class AttendanceViewModel : ViewModelBase
    {
        private readonly SchoolDbContextFactory _dbContextFactory;
        private Account _currentUserAccount;
        private IStudentService studentService;
        private ITeacherService teacherService;
        //private Attendance attendance;
        private DateTime selectedDate;
        private string selectedStudent;

        public string SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; OnPropertyChanged(nameof(SelectedStudent)); }
        }

        public DateTime SelectedDate
        {
            get { return selectedDate; }
            set { selectedDate = value; OnPropertyChanged(nameof(SelectedDate)); GetAttendance(); }
        }

        public Account CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }

        public ObservableCollection<Attendance> Attendances { get; set; }

        public AttendanceViewModel()
        {
            _dbContextFactory = new SchoolDbContextFactory();
            studentService = new DatabaseStudentService(new EntityFramework.SchoolDbContextFactory());
            teacherService = new DatabaseTeacherService(new EntityFramework.SchoolDbContextFactory());
            Attendances = new ObservableCollection<Attendance>();
            GetCurrentUser();
        }

        private void GetAttendance()
        {
            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                if (CurrentUserAccount.Role == "Student")
                {
                    var attendances = from l in dbContext.Lectures
                                      join sl in dbContext.Student_Lectures on l.Id equals sl.LectureId
                                      where sl.StudentId == CurrentUserAccount.Id && l.Date == DateOnly.FromDateTime(SelectedDate)
                                      select new Attendance()
                                      {
                                          Date = l.Date,
                                          SubjectName = l.SubjectName,
                                          IsPresent = sl.Attended
                                      };

                    Attendances.Clear();
                    foreach (var attendance in attendances)
                    {
                        Attendances.Add(attendance);
                    }
                }
                if(CurrentUserAccount.Role == "Teacher")
                {
                    var selectedStudent = dbContext.Students.FirstOrDefault(s => s.Username == SelectedStudent);

                    var attendances = from l in dbContext.Lectures
                                      join sl in dbContext.Student_Lectures on l.Id equals sl.LectureId
                                      where sl.StudentId == selectedStudent.Id && l.Date == DateOnly.FromDateTime(SelectedDate)
                                      select new Attendance()
                                      {
                                          Date = l.Date,
                                          SubjectName = l.SubjectName,
                                          IsPresent = sl.Attended
                                      };
                    
                    Attendances.Clear();
                    foreach (var attendance in attendances)
                    {
                        Attendances.Add(attendance);
                    }
                }
            }
        }

        private void GetCurrentUser()
        {
            var student = studentService.GetStudentByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (student == null)
            {
                var teacher = teacherService.GetTeacherByUsername(Thread.CurrentPrincipal.Identity.Name);
                CurrentUserAccount = new Account
                {
                    Id = teacher.Id,
                    Username = teacher.Username,
                    Password = teacher.Password,
                    DisplayName = $"Hello, {teacher.Username} :3",
                    Role = "Teacher"
                };
            }
            else if (student != null)
            {
                CurrentUserAccount = new Account
                {
                    Id = student.Id,
                    Username = student.Username,
                    Password = student.Password,
                    DisplayName = $"Hello, {student.Username} :3",
                    Role = "Student"
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
