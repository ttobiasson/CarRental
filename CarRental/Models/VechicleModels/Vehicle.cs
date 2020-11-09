using System.ComponentModel;

namespace CarRental.Models.VehicleModels
{
    public class Vehicle : INotifyPropertyChanged
    {
   
        private int mileage;
        private int kmPrice = 5;
        private int dayPrice = 500;

        public Vehicle(int mileage)
        {
           Mileage = mileage;
        }
       

        public void Deconstruct(out int varmileage)
        //used to enable a feature from C# 8.0, recursive patterns
        {
            varmileage = mileage;
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

        public int KmPrice { get { return kmPrice; } set { dayPrice = value; } }
        public int DayPrice { get { return dayPrice; } set { dayPrice = value; } }

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
