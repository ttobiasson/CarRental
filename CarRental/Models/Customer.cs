using System.ComponentModel;

namespace CarRental.Models
{
    public class Customer : INotifyPropertyChanged
    {
        private long personalIDnr;

        public Customer() { }
        public Customer(long personalIDnr)
        {
            this.personalIDnr = personalIDnr;
        }


        public long PersonalIDnr
        {
            get { return personalIDnr; }
            set { personalIDnr = value;
                  OnPropertyChanged("PersonalIDnr");
            }
        }
        public void Deconstruct(out long personalIDnr)
        {
            personalIDnr = PersonalIDnr;
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
