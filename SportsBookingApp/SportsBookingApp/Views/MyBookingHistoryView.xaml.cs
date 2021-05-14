using SportsBookingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportsBookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBookingHistoryView : ContentPage
    {
        MyBookingHistoryViewModel cvm;
        string UserName = Preferences.Get("UserName", String.Empty);

        public MyBookingHistoryView()
        {
            InitializeComponent();

            cvm = new MyBookingHistoryViewModel();
            this.BindingContext = cvm;
        }

        private async void SelectedBookingDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            cvm = new MyBookingHistoryViewModel(UserName, SelectedBookingDate.Date);

            this.BindingContext = cvm;


        }
    }
}