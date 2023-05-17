using Diploma.EntityFramework;
using Diploma.EntityFramework.Services.NotebookProviders;
using Diploma.EntityFramework.Services.NoteProviders;
using Diploma.WPF.ViewModels;
using Diploma.WPF.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Diploma.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string CONNECTION_STRING = "Server=RAOGPIP;Database=DiplomaDB;Trusted_Connection=True;TrustServerCertificate=True;";
        protected override void OnStartup(StartupEventArgs e)
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>().UseSqlServer(CONNECTION_STRING).Options;

            using (SchoolDbContext dbContext = new SchoolDbContext(options))
            {
                dbContext.Database.Migrate();
            }

            //INotebookService notebookService = new DatabaseNotebookService(new SchoolDbContextFactory());
            //INoteService noteService = new DatabaseNoteService(new SchoolDbContextFactory());

            //var viewModel = new EvernoteViewModel(notebookService, noteService);
            //var everNoteWindow = new EvernoteView { DataContext = viewModel };

            Window window = new MainWindow
            {
                DataContext = new MainViewModel()
            };
            window.Show();
            base.OnStartup(e);
        }
    }
}
