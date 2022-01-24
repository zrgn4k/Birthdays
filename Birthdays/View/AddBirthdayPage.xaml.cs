using Birthdays.Model;
using Birthdays.ViewModel;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Birthdays.View
{
    public partial class AddBirthdayPage : ContentPage
    {
        public AddBirthdayPage(ref ObservableCollection<BirthdayDate> _birthdayList)
        {
            InitializeComponent();
            BindingContext = new AddBirthdayViewModel(ref _birthdayList);
        }
    }
}
