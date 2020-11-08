using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CarRental.Models;
using CarRental.Models.Services;
using CarRental.Commands;


namespace CarRental.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        private BookingService objBookingService;
        private Booking currentBooking;


        public BookingViewModel()
        {
            objBookingService = new BookingService(); // The booking service holds the database implementation
            CurrentBooking = new Booking("init", new Vehicle(), new Customer(), 0);
            rentCommand = new ButtonCommand(Rent);
        }


        public Booking CurrentBooking
        {
            get { return  currentBooking; }
            set {
                currentBooking = value;
                OnPropertyChanged("CurrentBooking");
            }

        }
        
        public void Rent()
        //When the user clicks the "Rent" button, this method is called using ICommand
        {
            var result = CurrentBooking switch
            //Check if the booking information isn't complete
            {
                Booking("init", _, _, _) => "Error, no booking number",
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
            else { Message = result; }
            
            
        }
        public bool checkIfVehicle(string vehicleType)
        //Check if chosen vehicle type exists
        {
            var baseType = typeof(Vehicle);
            var assembly = typeof(Vehicle).Assembly;
            List<System.Type> types = assembly.GetTypes().Where(t => t.IsSubclassOf(baseType)).ToList();

            foreach (System.Type t in types)
            {
                if (t.ToString().Equals(vehicleType))
                {
                    return true;
                }
            }
            return false;
        }

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

        #region Rent ButtonCommand implementation
        private ButtonCommand rentCommand;

        public ButtonCommand RentCommand
        {
            get { return rentCommand; }
        }
        #endregion

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


    }
}
