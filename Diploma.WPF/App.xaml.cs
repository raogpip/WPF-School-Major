using Diploma.EntityFramework;
using Diploma.WPF.ViewModels;
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

            Window window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
            base.OnStartup(e);
        }
    }
}
