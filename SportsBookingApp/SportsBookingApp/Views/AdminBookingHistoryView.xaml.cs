using SportsBookingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportsBookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminBookingHistoryView : ContentPage
    {

        AdminBookingHistoryViewModel cvm;

        string s;
        string c;

        public AdminBookingHistoryView( string SelectedSportName, string CenterName)
        {
            InitializeComponent();

            s = SelectedSportName;
            c = CenterName;
            //cvm = new AdminBookingHistoryViewModel(SelectedSportName, CenterName, SelectedBookingDate.Date.DayOfWeek);
            cvm = new AdminBookingHistoryViewModel(SelectedSportName, CenterName);
            this.BindingContext = cvm;
        }

        private async void SelectedBookingDate_DateSelected(object sender, DateChangedEventArgs e)
        {

            // asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date);

            //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString());

            cvm = new AdminBookingHistoryViewModel(s, c, SelectedBookingDate.Date);
            //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date.DayOfWeek);

            this.BindingContext = cvm;


        }
    }
}