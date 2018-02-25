using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CSharpTask2
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        private Person _person;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDateTime = DateTime.Today;

        private RelayCommand _proceedCommand;
        
        internal MainWindowViewModel()
        {
        }

        public RelayCommand ProceedCommand
        {
            get
            {
                return _proceedCommand ?? (_proceedCommand = new RelayCommand(ProceedImplementation,
                           o => !string.IsNullOrWhiteSpace(_name) &&
                                !string.IsNullOrWhiteSpace(_surname) &&
                                !string.IsNullOrWhiteSpace(_email) && 
                                _birthDateTime != DateTime.MinValue));
            }
        }

        public string BirthDateText
        {
            get { return _birthDateTime.ToShortDateString(); }
        }

        public string IsAdult
        {
            get { return _person == null ? "" : _person.IsAdult ? "Yes!" : "No"; }
        }

        public string SunSign
        {
            get { return _person?.SunSign; }
        }

        public string ChineseSign
        {
            get { return _person?.ChineseSign; }
        }

        public string IsBirthday
        {
            get { return _person == null ? "" : _person.IsBirthday ? "Yes!" : "No"; }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value; 
                OnPropertyChanged();
            }
        }

        public DateTime BirthDateTime
        {
            get { return _birthDateTime; }
            set
            {
                _birthDateTime = value;
                OnPropertyChanged();
            }
        }

        private async void ProceedImplementation(object o)
        {
            await Task.Run(() =>
            {
                if (DateTime.Now.Year - _birthDateTime.Year >= 135 || DateTime.Now.Year - _birthDateTime.Year < 0)
                {
                    MessageBox.Show("Input correct birth day!", "ERROR");
                    _birthDateTime = DateTime.MinValue;
                }

                _person = new Person(Name, Surname, Email, BirthDateTime);

                if (_person.IsBirthday)
                {
                    MessageBox.Show("Happy birthday!", "Birthday greetings!");
                }

                Thread.Sleep(200);
            });
            OnPropertyChanged(nameof(BirthDateText));
            OnPropertyChanged(nameof(IsAdult));
            OnPropertyChanged(nameof(SunSign));
            OnPropertyChanged(nameof(ChineseSign));
            OnPropertyChanged(nameof(IsBirthday));
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
