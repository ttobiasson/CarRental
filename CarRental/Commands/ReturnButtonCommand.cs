using CarRental.ViewModels.ButtonViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarRental.Commands
{
    class ReturnButtonCommand : ICommand
    {
        private ReturnButtonViewModel _returnButtonViewModel;

        public ReturnButtonCommand(ReturnButtonViewModel returnButtonViewModel)
        {
            _returnButtonViewModel = returnButtonViewModel;
        }
        
        #region ICommand implementation
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _returnButtonViewModel.OnExecute();
        }
        #endregion
    }
}
