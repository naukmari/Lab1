using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CharpZavertailo1
{
    internal class DateViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBDay = DateTime.Today;
        private string _age;
        private string _westernZodiacSign;
        private string _chineseZodiacSign;
        private bool _canExecute;
        private RelayCommand<object> _calculate;

        private readonly Action<bool> _showLoaderAction;

        internal DateViewModel(Action<bool> showLoader)
        {
            _showLoaderAction = showLoader;
            CanExecute = true;
        }

        public bool CanExecute
        {
            get => _canExecute;
            private set
            {
                _canExecute = value;
                OnPropertyChanged();
            }
        }

        public DateTime Date
        {
            get => _dateOfBDay;
            set
            {
                _dateOfBDay = value;
                OnPropertyChanged();
            }
        }

        public string Age
        {
            get => _age;
            private set
            {
                _age = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiacSign
        {
            get => _westernZodiacSign;
            private set
            {
                _westernZodiacSign = value;
                OnPropertyChanged();
            }
        }

        public string ChineseZodiacSign
        {
            get => _chineseZodiacSign;
            private set
            {
                _chineseZodiacSign = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> Calculate => _calculate ?? (_calculate = new RelayCommand<object>(CalculationImplementation));

        private async void CalculationImplementation(object o)
        {
            _showLoaderAction.Invoke(true);
            Age = "";
            WesternZodiacSign = "";
            ChineseZodiacSign = "";
            await Task.Run(() =>
            {
                Manager.Date = Calculation.NewDate(_dateOfBDay);
                Thread.Sleep(3000);
            });

            if (Manager.Date == null)
                MessageBox.Show("You have chosen future date!");
            else
            {
                if (HappyBDay(_dateOfBDay))
                    MessageBox.Show("Happy birthday to you, happy birthday to you, happy birthday dear User, happy B-Day to YOU!");
                Age = $"Your age: {DateModel.Age}";
                WesternZodiacSign = $"Western zodiac sign: {Manager.Date.WesternZodiacSign}";
                ChineseZodiacSign = $"Chinese zodiac sign: {Manager.Date.ChineseZodiacSign}";
            }
            CanExecute = true;
            _showLoaderAction.Invoke(false);
        }

        public bool HappyBDay(DateTime dayOfBirthday)
        {
            return dayOfBirthday.DayOfYear == DateTime.Today.DayOfYear;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

    internal static class Manager
    {
        internal static DateModel Date { get; set; }
    }

    internal static class Calculation
    {
        internal static DateModel NewDate(DateTime date)
        {
            DateModel newDate;
            try
            {
                newDate = new DateModel(date);
            }
            catch (Exception)
            {
                return null;
            }
            return newDate;
        }
    }
}

