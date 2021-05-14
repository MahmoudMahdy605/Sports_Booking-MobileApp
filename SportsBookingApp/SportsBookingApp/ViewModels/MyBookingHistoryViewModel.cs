using SportsBookingApp.Models;
using SportsBookingApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Essentials;

namespace SportsBookingApp.ViewModels
{
    public class MyBookingHistoryViewModel : BaseViewModel
    {
        public MyBookingHistoryViewModel()
        {
            UserName = Preferences.Get("UserName", String.Empty);

            MyBookings = new ObservableCollection<Booking>();
        }

        public MyBookingHistoryViewModel(string username, DateTime bookingsdate)
        {
            UserName = username;

            MyBookings = new ObservableCollection<Booking>();

            GetBookingsByUserNameAndDate(username, bookingsdate);
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

        public ObservableCollection<Booking> MyBookings { get; set; }

        private async void GetBookingsByUserNameAndDate(string userName, DateTime bookingsDate)
        {
            var data = await new BookingDataService().GetBookingsByUserNameAndDateAsync(userName, bookingsDate);
            MyBookings.Clear();
            foreach (var item in data)
            {
                MyBookings.Add(item);
            }

        }
    }
}
