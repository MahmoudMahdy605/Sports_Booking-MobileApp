using SportsBookingApp.Models;
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
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        
        async void SportsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var sport = e.CurrentSelection.FirstOrDefault() as Sport;
            if (sport == null)
                return;

            // await NavigationService.NavigateAsync("test");
            await Navigation.PushModalAsync(new CentersView(sport));


            ((CollectionView)sender).SelectedItem = null;
            
        }
        

        async void CourtsCollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}