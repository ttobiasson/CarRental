using CarRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CarRental.Commands
{
    class RentButtonCommand : ICommand
    {
        private RentButtonViewModel _rentButtonViewModel;
        private Action MethodDelegate;

        public RentButtonCommand(Action method)
        {
            this.MethodDelegate = method;
        }



        #region ICommand implementation
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MethodDelegate();
        }
        #endregion
    }
}
