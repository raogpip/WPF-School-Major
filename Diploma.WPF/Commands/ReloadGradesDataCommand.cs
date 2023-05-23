using Diploma.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Diploma.WPF.Commands
{
    public class ReloadGradesDataCommand : ICommand
    {
        private GradesStatsViewModel _vm;

        public ReloadGradesDataCommand(GradesStatsViewModel vm)
        {
            _vm = vm;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _vm.CalculateGradesData();
        }
    }
}
