using Birthdays.ViewModel;
using System;
using System.Collections.ObjectModel;
using Birthdays.Model;
using Xamarin.Forms;

namespace Birthdays
{
    public partial class MainPage : ContentPage
    {
        public MainPage(ObservableCollection<BirthdayDate> collection)
        {
            InitializeComponent();
            BindingContext = new MainWindowViewModel(collection);
        }
    }
}
