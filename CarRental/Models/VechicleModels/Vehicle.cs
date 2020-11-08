using System.ComponentModel;

namespace CarRental.Models
{
    public class Vehicle : INotifyPropertyChanged
    {
   
        private string registrationNumber;
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
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value;
                OnPropertyChanged("RegistrationNumber");

            }
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
