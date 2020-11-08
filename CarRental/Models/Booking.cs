using System.ComponentModel;

namespace CarRental.Models
{
    public class Booking : INotifyPropertyChanged
    {
     
        private string bookingNumber;
        private Customer customer;
        private Vehicle vehicle;
        private int date;


        public Booking(){}
        public Booking(string bookingNumber, Vehicle v, Customer c, int date)
        {
            this.bookingNumber = bookingNumber;
            this.customer = c;
            this.vehicle = v;
            this.date = date;
        }


        public int Date
        {
            get { return date; }
            set { date = value;
                OnPropertyChanged("Date");
            }
        }
        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; 
                OnPropertyChanged("Vehicle"); 
            }
        }
        public Customer Customer
        {
            get { return customer; }
            set { customer = value;
                OnPropertyChanged("Customer");
            }
        }
        public string BookingNumber
        {
            get { return bookingNumber; }
            set { bookingNumber = value;
                OnPropertyChanged("BookingNumber");
            }
        }

        public void Deconstruct(out string bookingnr, out Vehicle vehicle, out Customer customer, out int date)
        //used to enable a feature from C# 8.0, recursive patterns
        {
            bookingnr = BookingNumber;
            vehicle = Vehicle;
            customer = Customer;
            date = Date;
            
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
    }
}
