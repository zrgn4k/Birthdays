using Birthdays.ViewModel;
using System.Collections.ObjectModel;
using Birthdays.Model;
using Xamarin.Forms;

namespace Birthdays
{
    public partial class MainPage : ContentPage
    {
        //public MainPage(ref ObservableCollection<BirthdayDate> col)
        //{
        //    InitializeComponent();
        //    BindingContext = new MainWindowViewModel(ref col);
        //}
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainWindowViewModel();
        }
    }
}
