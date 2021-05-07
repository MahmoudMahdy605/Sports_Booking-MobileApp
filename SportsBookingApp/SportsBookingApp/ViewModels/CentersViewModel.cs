using SportsBookingApp.Models;
using SportsBookingApp.Services;
using SportsBookingApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportsBookingApp.ViewModels
{
    public class CentersViewModel : BaseViewModel
    {
        public CentersViewModel( Sport sport)
        {
            SelectedSport = sport;
            CentersItemsBySport = new ObservableCollection<Center>();
            GetCenterItemsBySport(sport.SportName);

        }

        private Sport _SelectedSport;
        public Sport SelectedSport
        {
            set
            {
                _SelectedSport = value;
                OnpropertyChanged();
            }
            get
            {
                return _SelectedSport;
            }
        }
        /*
        private Center _SelectedCenter;
        public Center SelectedCenter
        {
            get { return _SelectedCenter; }
            set
            {
                _SelectedCenter = value;
                OnpropertyChanged();


            }
        }
        */

        private int _TotalCenters;

        public int TotalCenters
        {
            set
            {
                _TotalCenters = value;
                OnpropertyChanged();
            }
            get
            {
                return _TotalCenters;
            }
        }

        public ObservableCollection<Center> CentersItemsBySport { set; get; }
        /*
        public ObservableCollection<Center> CentersItemsBySport
        {
            set
            {
                _CentersItemsBySport = value;
                OnpropertyChanged();
            }
            get
            {
                return _CentersItemsBySport;
            }
        }
        */
        

        private async void GetCenterItemsBySport(string sportName)
        {
            var data = await new CenterService().GetCenterItemsBySportAsync(sportName);
            CentersItemsBySport.Clear();

            foreach (var item in data)
            {
                CentersItemsBySport.Add(item);
            }
            TotalCenters = CentersItemsBySport.Count();

            await Application.Current.MainPage.DisplayAlert("inside GetCenterItems ", " inside GetCenterItems", "OK");
        }
        /*
        void INavigatedAware.OnNavigatedTo(INavigationParameters parameters)
        {
            SelectedSport = parameters.GetValue<Sport>("SelectedSport");
            CentersItemsBySport = new ObservableCollection<Center>();
            GetCenterItemsBySport(SelectedSport.SportName);

            Application.Current.MainPage.DisplayAlert("inside OnNavigatedTo ", " inside OnNavigatedTo", "OK");
        }
        */

        /*
        public ICommand CentersCollectionView_SelectionChanged => new Command(CentersCollectionView);

        private async void CentersCollectionView()
        {

            // string sportname = SportName.Text.ToString();
            var center = _SelectedCenter;

            if (center == null)
            {
                await Application.Current.MainPage.DisplayAlert("error", "selectedCenter is null", "OK");
                return;
            }

            try
            {
                await Application.Current.MainPage.Navigation.PushModalAsync(new BookingView());
                //await _navigationService.NavigateAsync("BookingView", p);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            //await Navigation.PushModalAsync(new SignUpView());
            //await Navigation.PushModalAsync(new BookingView());
            //await Navigation.PushModalAsync(new BookingView(center, sportname));

            //((CollectionView)sender).SelectedItem = null;
            
            if (_SelectedCenter != null)
            {

                await Application.Current.MainPage.DisplayAlert("_SelectedCenter nooooot null", "_SelectedCenter nooooot null", "OK");

                var center = _SelectedCenter;
                if (center == null)
                {
                    await Application.Current.MainPage.DisplayAlert("center is null", "center is null", "OK");
                    return;
                }

                
                var p = new NavigationParameters();
                p.Add("SelectedCenter", center);
                p.Add("SelectedSportName", SelectedSport.SportName);

                await Application.Current.MainPage.DisplayAlert("after p", "after p", "OK");
                
                try
                {
                    await Application.Current.MainPage.Navigation.PushModalAsync(new BookingView());
                    //await _navigationService.NavigateAsync("BookingView", p);
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                }

            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "_SelectedCenter is null", "OK");
            }
            


        }
        */

    }
}
