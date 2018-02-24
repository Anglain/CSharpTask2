using System;
using System.ComponentModel;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CSharpTask2
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        private Person _person;

        private string _name;
        private string _surname;
        private string _email;
        private DateTime _birthDateTime;

        private RelayCommand _proceedCommand;

        private TextBlock _nameBlock;
        private TextBlock _surnameBlock;
        private TextBlock _emailBlock;
        private TextBlock _birthDateBlock;
        private TextBlock _isAdultBlock;
        private TextBlock _sunSignBlock;
        private TextBlock _chineseSignBlock;
        private TextBlock _isBirthdayBlock;

        internal MainWindowViewModel(TextBlock nameBlock, TextBlock surnameBlock, TextBlock emailBlock, TextBlock birthDateBlock,
            TextBlock isAdultBlock, TextBlock sunSignBlock, TextBlock chineseSignBlock, TextBlock isBirthdayBlock)
        {
            _nameBlock = nameBlock;
            _surnameBlock = surnameBlock;
            _emailBlock = emailBlock;
            _birthDateBlock = birthDateBlock;
            _isAdultBlock = isAdultBlock;
            _sunSignBlock = sunSignBlock;
            _chineseSignBlock = chineseSignBlock;
            _isBirthdayBlock = isBirthdayBlock;
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

            _nameBlock.Text = _name;
            _surnameBlock.Text = _surname;
            _emailBlock.Text = _email;
            _birthDateBlock.Text = _birthDateTime.ToShortDateString();
            _isAdultBlock.Text = (_person.IsAdult) ? "Yes!" : "No";
            _sunSignBlock.Text = _person.SunSign;
            _chineseSignBlock.Text = _person.ChineseSign;
            _isBirthdayBlock.Text = (_person.IsBirthday) ? "Yes!" : "No";
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

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
