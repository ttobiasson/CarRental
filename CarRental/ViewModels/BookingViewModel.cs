using System.ComponentModel;

namespace CarRental.ViewModels
{
    public class BookingViewModel : INotifyPropertyChanged
    {
        public BookingViewModel() {}


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
