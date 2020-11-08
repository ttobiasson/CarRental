using CarRental.ViewModels;
using System;
using System.Windows.Input;

namespace CarRental.Commands
{
    public class ButtonCommand : ICommand
    {
        private Action MethodDelegate;

        public ButtonCommand(Action method)
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
