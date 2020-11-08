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
            objBookingService = new BookingService(); // The booking service holds the database implementation
            CurrentBooking = new Booking();
            rentCommand = new RentButtonCommand(Rent);
        }

        #region Message to UI
        private string message;

        public string Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        #endregion

        public Booking CurrentBooking
        {
            get { return  currentBooking; }
            set {
                currentBooking = value switch
                {
                    Booking(_,null,null,_) => new Booking(value.BookingNumber,
                                                          new Van(),
                                                          new Customer(value.Customer.PersonalIDnr),
                                                          value.Date),

                    Booking(_,null,_,_) => new Booking(value.BookingNumber, 
                                                       new Van(), //Currently, only Van is supported
                                                       value.Customer, 
                                                       value.Date),                                    

                    Booking(_,_,null,_) => new Booking(value.BookingNumber, 
                                                       value.Vehicle, 
                                                       new Customer(value.Customer.PersonalIDnr), 
                                                       value.Date),
                    Booking(_,_,_,_) => value
                };
                OnPropertyChanged("CurrentBooking");
            }

        }
        
        public void Rent()
        //When the user clicks the "Rent" button, this method is called using ICommand
        {
            var result = CurrentBooking switch
            {
                Booking(null, _, _, _) => "Error, no booking number",
                Booking(_, null, _, _) => "Error, vehicle choice is incorrect",
                Booking(_, _, null, _) => "Error, customer information is incorrect",
                Booking(_, _, _, 0) => "Error, booking date is not entered",
                _ => "OK"
            };
            
            if(result.Equals("OK"))
            {
                
                var response = objBookingService.Add(CurrentBooking);

                Message = response;
            }
            else
            {
                Message = result;
            }
            
            
        }
        public Vehicle checkIfVehicle(string vehicleType)
        //Check if chosen vehicle type exists
        {
            var baseType = typeof(Vehicle);
            var assembly = typeof(Vehicle).Assembly;
            List<System.Type> types = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType)).ToList();

            foreach (System.Type t in types)
            {
                if (t.ToString().Equals(vehicleType))
                {
                    
                }
            }
            return null;
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
