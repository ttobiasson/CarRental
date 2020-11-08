﻿using CarRental.ViewModels;
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

        public RentButtonCommand(RentButtonViewModel rentButtonViewModel)
        {
            _rentButtonViewModel = rentButtonViewModel;
        }



        #region ICommand implementation
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _rentButtonViewModel.OnExecute();
        }
        #endregion
    }
}