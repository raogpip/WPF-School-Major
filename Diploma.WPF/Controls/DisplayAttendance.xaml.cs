using Diploma.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Diploma.WPF.Controls
{
    /// <summary>
    /// Interaction logic for DisplayAttendance.xaml
    /// </summary>
    public partial class DisplayAttendance : UserControl, INotifyPropertyChanged
    {
        public Attendance Attendance
        {
            get { return (Attendance)GetValue(AttendanceProperty); }
            set { SetValue(AttendanceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AttendanceProperty =
            DependencyProperty.Register("Attendance", typeof(Attendance), typeof(DisplayAttendance), new PropertyMetadata(null, SetValues));


        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DisplayAttendance attendanceUserControl = d as DisplayAttendance;
            if (attendanceUserControl != null)
            {
                attendanceUserControl.DataContext = attendanceUserControl.Attendance;
            }

            if(attendanceUserControl.Attendance.IsPresent == true)
            {
                attendanceUserControl.@checked.Visibility = Visibility.Visible;
                attendanceUserControl.@unchecked.Visibility = Visibility.Collapsed;
            }
            else
            {
                attendanceUserControl.@unchecked.Visibility = Visibility.Visible;
                attendanceUserControl.@checked.Visibility = Visibility.Collapsed;
            }
            
        }

        public DisplayAttendance()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
