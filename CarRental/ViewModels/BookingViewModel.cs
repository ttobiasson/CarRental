﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;

namespace CarRental.ViewModels
{
    class BookingViewModel : INotifyPropertyChanged
    {

        Booking booking;
        public BookingViewModel()
        {
            booking = new Booking();
        }
        public Booking Booking
        {
            get { return booking; }
            set { booking = value; 
                RaisePropertyChanged("Booking"); 
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
