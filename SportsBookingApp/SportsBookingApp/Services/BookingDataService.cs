using Firebase.Database;
using SportsBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBookingApp.Services
{
    public class BookingDataService
    {

        FirebaseClient client;
        public BookingDataService()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
        }

        /*
        public async Task<bool> IsCenterExists(string email)
        {
            var center = (await client.Child("Centers").OnceAsync<Center>()).Where(u => u.Object.CenterEmail == email).FirstOrDefault();

            return (center != null);
        }
        */

        public async Task<List<Booking>> GetBookingsItemsAsync()
        {
        var bookings = (await client.Child("Bookings").
            OnceAsync<Booking>()).
            Select(f => new Booking
            {
                SportName = f.Object.SportName,
                CourtName = f.Object.CourtName,
                Username = f.Object.Username,
                StartingBookingTime = f.Object.StartingBookingTime,
                EndingBookingTime = f.Object.EndingBookingTime,
                TotalPaymentAmount = f.Object.TotalPaymentAmount,
                CenterName = f.Object.CenterName,
                BookingDate = f.Object.BookingDate
            }).ToList();

        return bookings;
        }

        public async Task<ObservableCollection<Booking>> GetBookedSlotsItemsByCenterAndCourtAndDateAsync(string centerName, string courtName, DayOfWeek bookingDate)
        {

            var BookingItemsByCenterandCourtAndDate = new ObservableCollection<Booking>();
            var items = (await GetBookingsItemsAsync()).Where(p => p.BookingDate == bookingDate).Where(p => p.CenterName == centerName).Where(p => p.CourtName == courtName).ToList();

            foreach (var item in items)
            {
                BookingItemsByCenterandCourtAndDate.Add(item);
            }

            return BookingItemsByCenterandCourtAndDate;
        }



    }

}
