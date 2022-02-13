using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Birthdays.Model;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Birthdays
{
    public partial class App : Application
    {
        public XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<BirthdayDate>));
        public ObservableCollection<BirthdayDate> BirthdaysDeserialized = new ObservableCollection<BirthdayDate>();

        public App()
        {
            InitializeComponent();
        }
        
        protected override void OnStart()
        { 
            var documents = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var filename = Path.Combine(documents, "BirthdaysFile.xml");
            Debug.WriteLine(documents);
            using (var sr = new StreamReader(File.Open(filename, FileMode.OpenOrCreate, FileAccess.ReadWrite)))
            {
                BirthdaysDeserialized = (ObservableCollection<BirthdayDate>)xs.Deserialize(sr);
            }
            MainPage = new NavigationPage(new MainPage(BirthdaysDeserialized));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
