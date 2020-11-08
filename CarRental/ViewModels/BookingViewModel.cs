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

namespace CarRental.ViewModels
{
    class BookingViewModel : INotifyPropertyChanged
    {
        BookingService objBookingService;
        Booking booking;
        public BookingViewModel()
        {
            objBookingService = new BookingService();
            CurrentBooking = new Booking();
            rentCommand = new RentButtonCommand(Rent);
        }
        public Booking Booking
        {
            get { return booking; }
            set { booking = value; 
                OnPropertyChanged("Booking");
            }
        }
        private Booking currentBooking;

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
                    MessageBox.Show("Booking saved");
                }
                else
                {
                    MessageBox.Show("Save failed");
                }
            }
            catch (Exception e)
            {

            }
        }

        #region Rent Button ICommand implementation
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
