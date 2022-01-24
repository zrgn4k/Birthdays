using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Birthdays.Model;
using Xamarin.Forms;

namespace Birthdays.ViewModel
{
    public class AddBirthdayViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BirthdayDate> birthdayList;
        private readonly DateTime _dateMax = DateTime.Now;
        private DateTime _date;
        private string _name;
        public Command GoBackCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BirthdayDate> BirthdayList
        {
            get { return birthdayList; }
            set
            {
                birthdayList = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateMax
        {
            get { return _dateMax; }
        }

        public DateTime Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
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
        public AddBirthdayViewModel(ref ObservableCollection<BirthdayDate> _birthdayList)
        {
            birthdayList = _birthdayList;
            GoBackCommand = new Command(GoBack);
        }

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void GoBack()
        {
            if(string.IsNullOrEmpty(_name))
            {
                Application.Current.MainPage.DisplayAlert("Write name!", "Name field is empty", "OK");
            }

            else
            {
                BirthdayList.Add(new BirthdayDate(_date, _name));
                Application.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}