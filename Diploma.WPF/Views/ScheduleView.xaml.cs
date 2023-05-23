using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diploma.WPF.Views
{
    /// <summary>
    /// Interaction logic for ScheduleView.xaml
    /// </summary>
    public partial class ScheduleView : UserControl
    {
        private ScheduleViewModel _viewModel;
        public ScheduleView()
        {
            _viewModel = new ScheduleViewModel(new EntityFramework.SchoolDbContextFactory());
            InitializeComponent();
            if(_viewModel.CurrentUserAccount.Role == "Teacher")
            {
                teacherOnlyStackPanel.Visibility = Visibility.Visible;
            }
        }
    }
}
