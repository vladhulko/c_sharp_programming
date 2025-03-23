using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Lab01.Model;

namespace Lab01.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _birthDate;
        private Person _person;
        private bool _isAgeValid;
        private string _ageMessage;
        private string _birthdayMessage;
        private string _westernZodiac;
        private string _chineseZodiac;
        private bool _hasCalculated;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand CalculateCommand { get; private set; }

        public MainViewModel()
        {
            _person = new Person();
            BirthDate = DateTime.Today.AddYears(-20);
            CalculateCommand = new RelayCommand(CalculateAge);
            HasCalculated = false;
        }

        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                if (_birthDate != value)
                {
                    _birthDate = value;
                    _person.BirthDate = value;
                    OnPropertyChanged();
                    CalculateAge(null);
                }
            }
        }

        public string AgeMessage
        {
            get { return _ageMessage; }
            set
            {
                if (_ageMessage != value)
                {
                    _ageMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string BirthdayMessage
        {
            get { return _birthdayMessage; }
            set
            {
                if (_birthdayMessage != value)
                {
                    _birthdayMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set
            {
                if (_westernZodiac != value)
                {
                    _westernZodiac = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set
            {
                if (_chineseZodiac != value)
                {
                    _chineseZodiac = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool HasCalculated
        {
            get { return _hasCalculated; }
            set
            {
                if (_hasCalculated != value)
                {
                    _hasCalculated = value;
                    OnPropertyChanged();
                }
            }
        }

        private void CalculateAge(object obj)
        {
            _isAgeValid = _person.IsValidAge;

            if (!_isAgeValid)
            {
                MessageBox.Show("Неправильний вік! Вік має бути від 0 до 135 років.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                AgeMessage = "Неправильний вік";
                WesternZodiac = "";
                ChineseZodiac = "";
                BirthdayMessage = "";
            }
            else
            {
                AgeMessage = $"Ваш вік: {_person.Age} років";
                WesternZodiac = $"Західний знак зодіаку: {_person.WesternZodiacSign}";
                ChineseZodiac = $"Китайський знак зодіаку: {_person.ChineseZodiacSign}";

                if (_person.IsBirthday)
                {
                    BirthdayMessage = "З Днем Народження! 🎉";
                }
                else
                {
                    BirthdayMessage = "";
                }
            }

            HasCalculated = true;
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}