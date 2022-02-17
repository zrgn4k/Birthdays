using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Birthdays.Model;
using Birthdays.View;
using Xamarin.Forms;

namespace Birthdays.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public Command ShowPopCommand { get; }
        private ObservableCollection<BirthdayDate> _birthdayList;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<BirthdayDate> BirthdayList
        {
            get { return _birthdayList; }
            set
            {
                _birthdayList = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(ObservableCollection<BirthdayDate> DeserializedList)
        {
            _birthdayList = DeserializedList;
            ShowPopCommand = new Command(OnShowPop);
        }

        public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void OnShowPop()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AddBirthdayPage(ref _birthdayList));
        }
    }
}