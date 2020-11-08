using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Models;
using CarRental.Models.Services;
using CarRental.Commands;
using System.Windows;
using MySqlConnector;

namespace CarRental.ViewModels
{
    class BookingViewModel : INotifyPropertyChanged
    {
        BookingService objBookingService;
        private Booking currentBooking;
        public BookingViewModel()
        {
            objBookingService = new BookingService();
            CurrentBooking = new Booking();
            rentCommand = new RentButtonCommand(Rent);
        }



        
        public  Booking CurrentBooking
        {
            get { return  currentBooking; }
            set {  currentBooking = value;
                OnPropertyChanged("CurrentBooking");
            }
        }
        public void Rent()
        {
            try
            {
                var IsRented = objBookingService.Add(CurrentBooking);
                if (IsRented)
                {
                    
                }
                else
                {
                    //Message = "Booking failed";
                }
            }
            catch (Exception e)
            {
                //Message = e.Message;
            }
        }

        #region Rent Button Command implementation
        private RentButtonCommand rentCommand;

        public RentButtonCommand RentCommand
        {
            get { return rentCommand; }
        }
        #endregion


        #region Implementation of INotifyPropertyChanged
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
