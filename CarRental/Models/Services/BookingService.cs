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
        public bool Add(Booking objNewBooking)
        {
            string bookingNumber = objNewBooking.BookingNumber;
            //string customer = objNewBooking.Customer.ToString();
            //string vehicle = objNewBooking.Vehicle.ToString();
            string date = objNewBooking.Date.ToString();

            string connStr = "server=localhost;user=admin;database=bookings;password=hatarlolmanlane";
            try
            { 

            }
            catch (Exception ex)
            {
                //Message = ex.Message;
            }

            return true;
        }



    }
}
