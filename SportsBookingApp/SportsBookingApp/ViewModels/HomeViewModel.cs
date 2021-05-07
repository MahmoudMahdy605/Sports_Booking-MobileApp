using SportsBookingApp.Models;
using SportsBookingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportsBookingApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            var uname = Preferences.Get("UserName", String.Empty);
            if (String.IsNullOrEmpty(uname))
                UserName = "Guest";
            else UserName = uname;


            Sports = new ObservableCollection<Sport>();
            LatestItems = new ObservableCollection<Court>();

            GetSports();
            GetLatestItems();

        }

        private string _UserName;

        public string UserName
        {
            set
            {
                _UserName = value;
                OnpropertyChanged();
            }
            get
            {
                return _UserName;
            }
        }
        /*
        private Sport _SelectedSport;
        public Sport SelectedSport
        {
            get { return _SelectedSport; }
            set
            {
                _SelectedSport = value;
                OnpropertyChanged();
            }
        }
        */


        public ObservableCollection<Sport> Sports { get; set; }
        public ObservableCollection<Court> LatestItems { get; set; }


        private async void GetSports()
        {
            var data = await new SportDataService().GetSportsAsync();
            Sports.Clear();
            foreach (var item in data)
            {
                Sports.Add(item);
            }
        }

        private async void GetLatestItems()
        {
            var data = await new CourtDataService().GetLatestCourtsItemsAsync();
            LatestItems.Clear();
            foreach (var item in data)
            {
                LatestItems.Add(item);
            }
        }
        /*
        public ICommand SportsCollectionView_SelectionChanged => new Command(SportsCollectionView);

        private async void SportsCollectionView()
        {
            if (_SelectedSport != null)
            {
                
                var viewModel = new PlayerViewModel(selectedMusic, musicList);
                var playerPage = new PlayerPage { BindingContext = viewModel };
                
                var navigation = Application.Current.MainPage as NavigationPage;
                navigation.PushAsync(playerPage, true);
                
                // await Application.Current.MainPage.DisplayAlert("model", "model", "OK");

                var sport = _SelectedSport;
                if (sport == null)
                {
                    await Application.Current.MainPage.DisplayAlert("sport is null", "sport is null", "OK");
                    return;
                }


                var p = new NavigationParameters();
                p.Add("SelectedSport", sport);

                // await Application.Current.MainPage.DisplayAlert("after p", "after p", "OK");

                try
                {

                    // await Application.Current.MainPage.Navigation.PushModalAsync(new NormalTestViewModel());
                    await _navigationService.NavigateAsync("
View", p);
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }

                // ((CollectionView)sender).SelectedItem = null;

            }
        }
         */

    }
}
