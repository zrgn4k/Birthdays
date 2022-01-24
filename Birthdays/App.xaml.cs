using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Birthdays.Model;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Birthdays
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
        
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
