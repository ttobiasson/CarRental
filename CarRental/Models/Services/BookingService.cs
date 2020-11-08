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
        Booking booking = new Booking();

        public BookingService(Booking booking)
        {
            this.booking = booking;
        }
    }
}
