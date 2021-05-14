using SportsBookingApp.Models;
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
    public partial class AdminMainView : ContentPage
    {
        public AdminMainView()
        {
            InitializeComponent();
        }

        async void SportsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            var sport = e.CurrentSelection.FirstOrDefault() as Sport;
            if (sport == null)
                return;

            await Navigation.PushModalAsync(new AdminBookingHistoryView(sport.SportName, centername.Text));


            ((CollectionView)sender).SelectedItem = null;

        }
    }
}