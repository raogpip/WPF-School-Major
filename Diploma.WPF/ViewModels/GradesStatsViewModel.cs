using Diploma.Domain.Models;
using Diploma.EntityFramework;
using Diploma.EntityFramework.Services.StudentProviders;
using Diploma.EntityFramework.Services.TeacherProviders;
using Diploma.WPF.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Diploma.WPF.ViewModels
{
    public class GradesStatsViewModel : ViewModelBase
    {
        private readonly SchoolDbContextFactory _dbContextFactory;
        private Account _currentUserAccount;
        private IStudentService studentService;
        private ITeacherService teacherService;
        private int gradeCount;
        private double average;
        private string selectedSubject;
        private int count5 = 0;
        private int count4 = 0;
        private int count3 = 0;
        private int count2 = 0;
        private int count1 = 0;
        private string selectedStudent;

        public string SelectedStudent
        {
            get { return selectedStudent; }
            set { selectedStudent = value; OnPropertyChanged(nameof(SelectedStudent)); CalculateGradesData(); }
        }

        public Account CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }
        public int GradeCount
        {
            get { return gradeCount; }
            set { gradeCount = value; OnPropertyChanged(nameof(GradeCount)); }
        }
        public double Average
        {
            get { return average; }
            set { average = value; OnPropertyChanged(nameof(Average)); }
        }
        public string SelectedSubject
        {
            get { return selectedSubject; }
            set { selectedSubject = value; OnPropertyChanged(nameof(SelectedSubject)); UpdateSubjectGradesData(); }
        }

        public int Count1
        {
            get { return count1; }
            set { count1 = value; OnPropertyChanged(nameof(Count1)); }
        }

        public int Count2
        {
            get { return count2; }
            set { count2 = value; OnPropertyChanged(nameof(Count2)); }
        }

        public int Count3
        {
            get { return count3; }
            set { count3 = value; OnPropertyChanged(nameof(Count3)); }
        }

        public int Count4
        {
            get { return count4; }
            set { count4 = value; OnPropertyChanged(nameof(Count4)); }
        }

        public int Count5
        {
            get { return count5; }
            set { count5 = value; OnPropertyChanged(nameof(Count5)); }
        }

        public ReloadGradesDataCommand ReloadGradesDataCommand { get; set; }

        public GradesStatsViewModel()
        {
            _dbContextFactory = new SchoolDbContextFactory();
            studentService = new DatabaseStudentService(new EntityFramework.SchoolDbContextFactory());
            teacherService = new DatabaseTeacherService(new EntityFramework.SchoolDbContextFactory());
            ReloadGradesDataCommand = new ReloadGradesDataCommand(this);
            GetCurrentUser();
            CalculateGradesData();
        }

        private void UpdateSubjectGradesData()
        {
            if (SelectedSubject != null)
            {

                if (CurrentUserAccount.Role == "Student")
                {


                    switch (SelectedSubject)
                    {
                        case "System.Windows.Controls.ComboBoxItem: Математика":
                            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
                            {
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 1).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 1).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 1).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 1).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 1).Count();
                            }
                            break;
                        case "System.Windows.Controls.ComboBoxItem: Українська мова":
                            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
                            {
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 2).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 2).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 2).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 2).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 2).Count();
                            }
                            break;
                        case "System.Windows.Controls.ComboBoxItem: Фізика":
                            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
                            {
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 3).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 3).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 3).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 3).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 3).Count();
                            }
                            break;
                        case "System.Windows.Controls.ComboBoxItem: Фізкультура":
                            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
                            {
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 4).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 4).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 4).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 4).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 4).Count();
                            }
                            break;
                        case "System.Windows.Controls.ComboBoxItem: Малювання":
                            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
                            {
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 5).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 5).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 5).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 5).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == CurrentUserAccount.Id && g.SubjectId == 5).Count();
                            }
                            break;
                        default:
                            break;
                    }
                }
                if (CurrentUserAccount.Role == "Teacher")
                {

                    using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
                    {
                        var selectedStudent = dbContext.Students.FirstOrDefault(s => s.Username == SelectedStudent);
                        switch (SelectedSubject)
                        {

                            case "System.Windows.Controls.ComboBoxItem: Математика":
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == selectedStudent.Id && g.SubjectId == 1).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == selectedStudent.Id && g.SubjectId == 1).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == selectedStudent.Id && g.SubjectId == 1).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == selectedStudent.Id && g.SubjectId == 1).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == selectedStudent.Id && g.SubjectId == 1).Count();

                                break;
                            case "System.Windows.Controls.ComboBoxItem: Українська мова":
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == selectedStudent.Id && g.SubjectId == 2).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == selectedStudent.Id && g.SubjectId == 2).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == selectedStudent.Id && g.SubjectId == 2).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == selectedStudent.Id && g.SubjectId == 2).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == selectedStudent.Id && g.SubjectId == 2).Count();

                                break;
                            case "System.Windows.Controls.ComboBoxItem: Фізика":
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == selectedStudent.Id && g.SubjectId == 3).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == selectedStudent.Id && g.SubjectId == 3).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == selectedStudent.Id && g.SubjectId == 3).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == selectedStudent.Id && g.SubjectId == 3).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == selectedStudent.Id && g.SubjectId == 3).Count();

                                break;
                            case "System.Windows.Controls.ComboBoxItem: Фізкультура":
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == selectedStudent.Id && g.SubjectId == 4).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == selectedStudent.Id && g.SubjectId == 4).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == selectedStudent.Id && g.SubjectId == 4).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == selectedStudent.Id && g.SubjectId == 4).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == selectedStudent.Id && g.SubjectId == 4).Count();
                                break;
                            case "System.Windows.Controls.ComboBoxItem: Малювання":
                                Count5 = dbContext.Grades.Where(g => g.GradeValue == 5 && g.StudentId == selectedStudent.Id && g.SubjectId == 5).Count();
                                Count4 = dbContext.Grades.Where(g => g.GradeValue == 4 && g.StudentId == selectedStudent.Id && g.SubjectId == 5).Count();
                                Count3 = dbContext.Grades.Where(g => g.GradeValue == 3 && g.StudentId == selectedStudent.Id && g.SubjectId == 5).Count();
                                Count2 = dbContext.Grades.Where(g => g.GradeValue == 2 && g.StudentId == selectedStudent.Id && g.SubjectId == 5).Count();
                                Count1 = dbContext.Grades.Where(g => g.GradeValue == 1 && g.StudentId == selectedStudent.Id && g.SubjectId == 5).Count();
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }

        public void CalculateGradesData()
        {

            using (SchoolDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                double sum = 0.0;

                if (CurrentUserAccount.Role == "Student")
                {

                    GradeCount = dbContext.Grades.Select(g => g.StudentId == CurrentUserAccount.Id).Count();
                    List<Grade> grades = dbContext.Grades.Where(g => g.StudentId == CurrentUserAccount.Id).ToList();

                    foreach (var grade in grades)
                    {
                        sum += grade.GradeValue;
                    }
                    Average = sum / GradeCount;
                }
                if (CurrentUserAccount.Role == "Teacher")
                {
                    var selectedStudent = dbContext.Students.FirstOrDefault(s => s.Username == SelectedStudent);
                    if (selectedStudent != null)
                    {

                        GradeCount = dbContext.Grades.Select(g => g.StudentId == selectedStudent.Id).Count();
                        List<Grade> grades = dbContext.Grades.Where(g => g.StudentId == selectedStudent.Id).ToList();

                        foreach (var grade in grades)
                        {
                            sum += grade.GradeValue;
                        }
                        Average = sum / GradeCount;
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
