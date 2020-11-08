using CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CarRental.ViewModels.ButtonViewModels
{
    class ReturnButtonViewModel
    {
        public ReturnButtonCommand ReturnButtonCommand { get; set; }
        public ReturnButtonViewModel()
        {
            ReturnButtonCommand = new ReturnButtonCommand(this);
        }
        public void OnExecute()
        {
            MessageBox.Show("Return");
        }
    }
}
