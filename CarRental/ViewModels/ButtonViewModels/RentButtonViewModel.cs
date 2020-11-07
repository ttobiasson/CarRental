using CarRental.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CarRental.ViewModels
{
    class RentButtonViewModel
    {
        public RentButtonCommand RentButtonCommand { get; set; }
        public RentButtonViewModel()
        {
            RentButtonCommand = new RentButtonCommand(this);
        }
        public void OnExecute()
        {
           
        }
    }
}
