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
    /// Interaction logic for InformationView.xaml
    /// </summary>
    public partial class InformationView : UserControl
    {
        public InformationView()
        {
            InitializeComponent();
        }

        public void HideAll()
        {
            scheduleInfo.Visibility = Visibility.Collapsed;
            attendanceInfo.Visibility = Visibility.Collapsed;
            gradesInfo.Visibility = Visibility.Collapsed;
            notesInfo.Visibility = Visibility.Collapsed;
        }

        private void notesButton_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            notesInfo.Visibility = Visibility.Visible;
        }

        private void gradesButton_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            gradesInfo.Visibility = Visibility.Visible;
        }

        private void attendanceButton_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            attendanceInfo.Visibility = Visibility.Visible;
        }

        private void scheduleButton_Click(object sender, RoutedEventArgs e)
        {
            HideAll();
            scheduleInfo.Visibility = Visibility.Visible;
        }
    }
}
