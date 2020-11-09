using CarRental.Commands;
using CarRental.Models.VehicleModels;
using CarRental.ViewModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CarRental.Models.Services
{
    public class BookingService : INotifyPropertyChanged
    {
        private Booking currentBooking;

        public BookingService()
        {
            this.currentBooking   = new Booking("Change me", new Van(), new Customer(0), 0);
            rentCommand           = new ButtonCommand(Rent);
        }

        public Booking CurrentBooking
        {
            get { return currentBooking; }
            set { currentBooking = value; OnPropertyChanged("CurrentBooking"); }
        }
        public void Rent()
        //When the user clicks the "Rent" button, this method is called using ICommand
        {
            var result = CheckCurrentBooking(CurrentBooking);

            if (result.Equals("OK"))
            {
                var response = AddBookingToDatabase(CurrentBooking);
                Message = response;
            }
            else { Message = result; }

        }

        public string CheckCurrentBooking(Booking currentbooking)
        {
            var result = currentbooking switch
            //Check if the booking information isn't complete
            {
                Booking(null, _, _, _) => "Error, no booking number",
                Booking(_, null, _, _) => "Error, vehicle choice is incorrect",
                Booking(_, _, null, _) => "Error, customer information is incorrect",
                Booking(_, _, _, 0) => "Error, booking date is not entered",
                _ => "OK"
            };

            return result;
        }

        public bool CheckIfExtendsVehicle(string vehicleType)
        //Check if class extends Vehicle (I.E is a Vehicle)
        //so we can verify user input, not yet used
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
        

        public string AddBookingToDatabase(Booking objNewBooking)
        {
            string bookingNumber = objNewBooking.BookingNumber;
            string customer = objNewBooking.Customer.PersonalIDnr.ToString();
            string vehicle = objNewBooking.Vehicle.GetType().ToString();
            string date = objNewBooking.Date.ToString();
            string mileage = objNewBooking.Vehicle.Mileage.ToString();

            try
            {
                var cs = "Host=localhost;Username=postgres;Password=hatarlolmanlane;Database=bookings";

                using var con = new NpgsqlConnection(cs);
                con.Open();
                
                var insertSQL = 
                    "INSERT INTO bookings VALUES (" +
                    "\'" + bookingNumber + "\',"
                         + customer      + "," +
                    "\'" + vehicle       + "\'," 
                         + date          + "," 
                         + mileage       + ")";

                var selectSQL = "SELECT * FROM bookings";

                using var insert = new NpgsqlCommand(insertSQL, con);
                using var select = new NpgsqlCommand(selectSQL, con);

                insert.ExecuteScalar();
                
                var response = select.ExecuteScalar();
                if(response != null)
                {
                    return "Booking placed";
                }
                else
                {
                    return "Nothing to show";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
        }
        #region Message
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
    }
}
