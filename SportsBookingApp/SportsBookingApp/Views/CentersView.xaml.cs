using SportsBookingApp.Models;
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
    public partial class CentersView : ContentPage
    {

        CentersViewModel cvm;

        public CentersView( Sport sport )
        {
            InitializeComponent();

            cvm = new CentersViewModel(sport);
            this.BindingContext = cvm;

        }
        

        async void CentersCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sportname = SportName.Text.ToString();
            var center = e.CurrentSelection.FirstOrDefault() as Center;

            if (center == null)
            {
                //await Application.Current.MainPage.DisplayAlert("error", "selectedCenter is null", "OK");
                return;
            }

            //await Navigation.PushModalAsync(new SignUpView());
            //await Navigation.PushModalAsync(new BookingView());
            await Navigation.PushModalAsync(new BookingView(center, sportname));

            ((CollectionView)sender).SelectedItem = null;
            
        }
        


    }
}