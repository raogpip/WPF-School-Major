using Diploma.Domain.Models;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Diploma.WPF.Controls
{
    /// <summary>
    /// Interaction logic for DisplayLecture.xaml
    /// </summary>
    public partial class DisplayLecture : UserControl, INotifyPropertyChanged
    {
        public Lecture Lecture
        {
            get { return (Lecture)GetValue(LectureProperty); }
            set { SetValue(LectureProperty, value); }
        }

        private string lectureName;

        public string LectureName
        {
            get { return lectureName; }
            set { lectureName = value; OnPropertyChanged(nameof(LectureName)); GetLectureName(); }
        }


        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LectureProperty =
            DependencyProperty.Register("Lecture", typeof(Lecture), typeof(DisplayLecture), new PropertyMetadata(null, SetValues));


        private static void SetValues(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DisplayLecture lectureUserControl = d as DisplayLecture;
            if (lectureUserControl != null)
            {
                lectureUserControl.DataContext = lectureUserControl.Lecture;
            }
        }

        public DisplayLecture()
        {
            InitializeComponent();
            GetLectureName();
        }

        private void GetLectureName()
        {
            if(Lecture != null)
            {
                switch (Lecture.SubjectId)
                {
                    case 1:
                        LectureName = "Математика";
                        break;
                    case 2:
                        LectureName = "Українська мова";
                        break;
                    case 3:
                        LectureName = "Фізика";
                        break;
                    case 4:
                        LectureName = "Фізкультура";
                        break;
                    case 5:
                        LectureName = "Малювання";
                        break;
                    default:
                        LectureName = "UNKNOWN";
                        break;
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
