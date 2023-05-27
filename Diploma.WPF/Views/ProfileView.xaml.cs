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
using static System.Net.Mime.MediaTypeNames;

namespace Diploma.WPF.Views
{
    /// <summary>
    /// Interaction logic for ProfileView.xaml
    /// </summary>
    public partial class ProfileView : UserControl
    {
        private ProfileViewModel vm;
        public ProfileView()
        {
            vm = new ProfileViewModel();
            InitializeComponent();
            if(vm.CurrentUserAccount.Sex == "F")
            {
                avatar.ImageSource = (ImageSource)Resources["female_avatarDrawingImage"];
            }
        }
    }
}
