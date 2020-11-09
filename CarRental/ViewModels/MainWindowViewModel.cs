using System.ComponentModel;

namespace CarRental.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private object _currentView; // Will be used in the future to implement 
                                     // changing view when a button is pressed.

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }
        

        #region Implementation of INotifyPropertyChanged
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
