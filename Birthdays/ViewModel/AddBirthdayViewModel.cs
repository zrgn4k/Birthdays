using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Birthdays.Model;
using Plugin.LocalNotification;
using Xamarin.Forms;

namespace Birthdays.ViewModel
{
    public class AddBirthdayViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<BirthdayDate> birthdayList;
        private readonly DateTime _dateMax = DateTime.Now;
        private int _id = 0;
        private TimeSpan isLeap;
        private DateTime _date;
        private string _name;
        public Command GoBackCommand { get; }
        public XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<BirthdayDate>));
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
            if (string.IsNullOrEmpty(_name))
            {
                Application.Current.MainPage.DisplayAlert("Write name!", "Name field is empty", "OK");
            }

            else
            {
                if (_id != 0)
                { 
                    _id = BirthdayList[BirthdayList.Count].Id;
                }

                _id++;
                BirthdayList.Add(new BirthdayDate(_date, _name, _id));
                Application.Current.MainPage.Navigation.PopAsync();

                if (_date.Day % 4 == 0)
                {
                    isLeap = new TimeSpan(365, 0, 0, 0);
                }

                else
                {
                    isLeap = new TimeSpan(366, 0, 0, 0);
                }

                var notification = new NotificationRequest
                {
                    BadgeNumber = 1,
                    Title = "Birthday!",
                    Description = "Today " + _name + " birthday!",
                    NotificationId = _id,
                    Schedule =
                    {
                        NotifyTime = _date,
                        NotifyRepeatInterval = isLeap,
                        RepeatType = NotificationRepeat.TimeInterval
                    }
                };

                NotificationCenter.Current.Show(notification);

                Debug.WriteLine($"Added birthday with id:{_id}");

                var documents = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                var filename = Path.Combine(documents, "BirthdaysFile.xml");
                Debug.WriteLine(documents);
                using (var sw = new StreamWriter(File.Open(filename,FileMode.OpenOrCreate,FileAccess.ReadWrite)))
                {
                    xs.Serialize(sw, birthdayList);
                }
            }
        }
    }
}