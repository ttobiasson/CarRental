﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace CarRental.Models
{
    public class Booking : INotifyPropertyChanged
    {

        #region Code for INotifiedPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        public Booking()
        {
            
        }
        public Booking(string bookingNumber, Vehicle v, Customer c, int date)
        {
            this.bookingNumber = bookingNumber;
            this.customer = c;
            this.vehicle = v;
            this.date = date;
        }
        private string bookingNumber;
        private Customer customer;
        private Vehicle vehicle;
        private int date;

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
        {
            bookingnr = BookingNumber;
            vehicle = Vehicle;
            customer = Customer;
            date = Date;
            
        }

    }
}
