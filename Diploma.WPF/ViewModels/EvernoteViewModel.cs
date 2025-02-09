using Diploma.Domain.Models;
using Diploma.EntityFramework.Services.NotebookProviders;
using Diploma.EntityFramework.Services.NoteProviders;
using Diploma.EntityFramework.Services.StudentProviders;
using Diploma.EntityFramework.Services.TeacherProviders;
using Diploma.WPF.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;

namespace Diploma.WPF.ViewModels
{
    public class EvernoteViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly INotebookService _notebookService;
        private readonly INoteService _noteService;
        private readonly IStudentService _studentService;
        private readonly ITeacherService _teacherService;
        private Account _currentUserAccount;
        private Notebook selectedNotebook;
        private Note selectedNote;
        private Visibility isVisible;

        public Account CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }
        }


        public Notebook SelectedNotebook
        {
            get { return selectedNotebook; }
            set
            {
                selectedNotebook = value;
                OnPropertyChanged(nameof(SelectedNotebook));
                GetNotes();
            }

        }

        public Note SelectedNote
        {
            get { return selectedNote; }
            set
            {
                selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
                SelectedNoteChanged?.Invoke(this, new EventArgs());
            }
        }

        public Visibility IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; OnPropertyChanged(nameof(IsVisible)); }
        }


        public ObservableCollection<Notebook> Notebooks { get; set; }
        public ObservableCollection<Note> Notes { get; set; }

        public NewNotebookCommand NewNotebookCommand { get; set; }
        public NewNoteCommand NewNoteCommand { get; set; }
        public EditCommand EditCommand { get; set; }
        public EndEditCommand EndEditingCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler SelectedNoteChanged;


        public EvernoteViewModel(INotebookService notebookService, INoteService noteService)
        {
            _studentService = new DatabaseStudentService(new EntityFramework.SchoolDbContextFactory());
            _teacherService = new DatabaseTeacherService(new EntityFramework.SchoolDbContextFactory());
            _notebookService = notebookService;
            _noteService = noteService;

            NewNoteCommand = new NewNoteCommand(this);
            NewNotebookCommand = new NewNotebookCommand(this);
            EditCommand = new EditCommand(this);
            EndEditingCommand = new EndEditCommand(this);

            Notebooks = new ObservableCollection<Notebook>();
            Notes = new ObservableCollection<Note>();
            IsVisible = Visibility.Collapsed;
            GetCurrentUser();
            GetNotebooks();
        }
        private void GetCurrentUser()
        {
            var student = _studentService.GetStudentByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (student == null)
            {
                var teacher = _teacherService.GetTeacherByUsername(Thread.CurrentPrincipal.Identity.Name);
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

        public void CreateNotebook()
        {
            var notebookCounter = _notebookService.GetAllNotebooks().Where(nb => nb.UserId == CurrentUserAccount.Id).Count();
            Notebook notebook = new Notebook
            {
                Name = $"{CurrentUserAccount.Username}'s notebook {notebookCounter + 1}",
                UserId = CurrentUserAccount.Id
            };
            _notebookService.InsertNotebook(notebook);
            GetNotebooks();
        }

        public void CreateNote(int noteBookID)
        {
            Note newNote = new Note()
            {
                NotebookId = noteBookID,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Title = $"Note for {DateTime.Now}"
            };
            _noteService.InsertNote(newNote);
            GetNotes();
        }

        private void GetNotebooks()
        {
            Notebooks.Clear();
            var notebooks = _notebookService.GetAllNotebooks().Where(nb => nb.UserId == CurrentUserAccount.Id);
            foreach (var notebook in notebooks)
            {
                Notebooks.Add(notebook);
            }
        }

        private void GetNotes()
        {
            if (SelectedNotebook != null)
            {
                var notes = _noteService.GetAllNotes().Where(n => n.NotebookId == SelectedNotebook.Id).ToList();
                Notes.Clear();
                foreach (var note in notes)
                {
                    Notes.Add(note);
                }
            }
        }


        public void StartEditing()
        {
            IsVisible = Visibility.Visible;
        }

        public void StopEditing(Notebook notebook)
        {
            IsVisible = Visibility.Collapsed;
            _notebookService.UpdateNotebook(notebook);
            GetNotebooks();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
