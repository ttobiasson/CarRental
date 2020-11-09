using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CarRental.Models;
using CarRental.Models.Services;
using CarRental.Commands;
using System;
using CarRental.Models.VehicleModels;

namespace CarRental.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {


        public BookingViewModel() {}


        #region INotifiedPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        



    }
}
