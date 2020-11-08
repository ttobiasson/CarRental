using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace CarRental.Models
{
    public abstract class Vehicle :INotifyPropertyChanged
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

        private string registrationNr;
        private int mileage;

        public float CalculatePrice()
        {
            return 0;
        }

        public int Mileage
        {
            get { return mileage; }
            set
            {
                mileage = value;
                OnPropertyChanged("Mileage");
            }
        }
    }
}
