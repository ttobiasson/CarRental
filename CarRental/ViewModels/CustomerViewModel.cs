using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.ViewModels
{
    class CustomerViewModel : INotifyPropertyChanged
    {
        Customer customer;

        public CustomerViewModel(int personalIDnr)
        {
            customer = new Customer(PersonalIDnr);
        }
        
        public int PersonalIDnr
        {
            get { return customer.PersonalIDnr; }
            set { 
                if(customer.PersonalIDnr != value)
                {
                    customer.PersonalIDnr = value;
                    RaisePropertyChanged("PersonalIDnr");

                }
            }
        }

        #region Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
