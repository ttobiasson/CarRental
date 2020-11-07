﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CarRental.Models
{
    public class Customer : INotifyPropertyChanged
    {

        #region Code for INotifiedPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
        

        public Customer(int personalIDnr)
        {
            this.personalIDnr = personalIDnr;
        }

        private int personalIDnr;

        public int PersonalIDnr
        {
            get { return personalIDnr; }
            set { personalIDnr = value;
                  OnPropertyChanged("PersonalIDnr");
            }
        }
    }
}
