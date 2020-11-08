using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Models.Services
{
    class BookingService
    {

        //Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;
        private static List<Booking> ObjBookingList;

        public BookingService()
        {
            ObjBookingList = new List<Booking>()
            {
                new Booking()
            };
        }
        public bool Add(Booking objNewBooking)
        {
            ObjBookingList.Add(objNewBooking);
            if (!ObjBookingList.Contains(objNewBooking))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
