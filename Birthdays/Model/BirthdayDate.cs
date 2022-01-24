using System;
using System.Xml.Serialization;

namespace Birthdays.Model
{
    public class BirthdayDate
    {
        DateTime _date;
        string _currentDate;
        string _name;
        int _age;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public DateTime BirthDate
        {
            get { return _date; }
            set { _date = value; }
        }

        public string CurrentDate
        {
            get { return _currentDate; }
        }

        public int Age
        {
            get { return _age; }
        }

        public BirthdayDate(DateTime date, string name)
        {
            _date = date;
            _name = name;
            _age = DateTime.Now.Year - date.Year;
            _currentDate = date.ToString("MM/dd/yyyy");
        }
    }
}
