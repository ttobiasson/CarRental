using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarRental.Models.Services
{
    class BookingService : INotifyPropertyChanged
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


        
        public string Add(Booking objNewBooking)
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
                    "\'" + bookingNumber + "\'," +
                    customer + "," +
                    "\'" + vehicle + "\'," +
                    date + "," +
                    mileage +
                    ")";

                var selectSQL = "SELECT * FROM bookings";

                using var insert = new NpgsqlCommand(insertSQL, con);
                using var select = new NpgsqlCommand(selectSQL, con);

                insert.ExecuteScalar();
                
                var response = select.ExecuteScalar();
                if(response != null)
                {
                    return response.ToString();
                }
                else
                {
                    return "Null";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            
        }



    }
}
