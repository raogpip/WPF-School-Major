using Diploma.WPF.Commands;
using Diploma.WPF.Models;
using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.State.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel 
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel= value;
                OnPropertyChanged(nameof(CurrentViewModel));
            } 
        }

        public ICommand UpdateCurrentViewModelCommand => new UpdateCurrentViewModelCommand(this);

      
    }
}
