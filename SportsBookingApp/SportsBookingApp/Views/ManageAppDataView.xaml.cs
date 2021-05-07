using SportsBookingApp.Helpers;
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
    public partial class ManageAppDataView : ContentPage
    {
        public ManageAppDataView()
        {
            InitializeComponent();
        }

        private async void ButtonSports_Clicked(object sender, EventArgs e)
        {
            var acd = new AddSportData();
            await acd.AddSportDataAsync();
        }

        private async void ButtonCourts_Clicked(object sender, EventArgs e)
        {
            var afd = new AddCourtData();
            await afd.AddCourtDataAsync();
        }

        private async void ButtonCenters_Clicked(object sender, EventArgs e)
        {
            var atd = new AddCenterData();
            await atd.AddCenterDataAsync();
        }

        private async void ButtonBookings_Clicked(object sender, EventArgs e)
        {
            var ard = new AddBookingData();
            await ard.AddBookingDataAsync();
        }

    }
}