using System;
using System.Xml.Serialization;
using Xamarin.Forms.Internals;

namespace Birthdays.Model
{
    [Preserve]
    public class BirthdayDate
    {
        int _id;
        DateTime _date;
        string _currentDate;
        string _name;
        int _age;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlIgnore]
        public DateTime BirthDate
        {
            get { return _date; }
            set { _date = value; }
        }

        public string BirthDateString
        {
            get { return BirthDate.ToString("dd/MM/yyyy"); }
            set
            {
                CurrentDate = value;
                BirthDate = DateTime.Parse(value);
                Age = (int)((DateTime.Now - DateTime.Parse(value)).TotalDays / 365.25);
            }
        }

        [XmlIgnore]
        public string CurrentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        [XmlIgnore]
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        public BirthdayDate()
        {
        }

        public BirthdayDate(DateTime date, string name, int id)
        {
            _id = id;
            _name = name;
            BirthDateString = date.ToString("dd/MM/yyyy");
        }
    }
}
