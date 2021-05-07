using Firebase.Database;
using Firebase.Database.Query;
using SportsBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportsBookingApp.Helpers
{
    public class AddBookingData
    {
        FirebaseClient client;
        public List<Booking> Bookings { get; set; }


        /*
        public AddBookingData(string sportName, string courtName, string userName, string centerName, DateTime startingBookingTime, DateTime endingBookingTime, DayOfWeek bookingDate, double totalPaymentAmount)
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
            Bookings = new List<Booking>()
            {
                new Booking
                {
                    SportName = sportName,
                    CourtName = courtName,
                    Username = userName,
                    CenterName = centerName,
                    StartingBookingTime = startingBookingTime,
                    EndingBookingTime = endingBookingTime,
                    BookingDate = bookingDate,
                    TotalPaymentAmount = totalPaymentAmount

                }
            };
        }
        */

        public AddBookingData()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
            Bookings = new List<Booking>()
            {
                new Booking
                {
                    SportName = "Futsal",
                    CourtName = "Court 1",
                    Username = "Moustafa",
                    CenterName = "BBC Futsal Center",
                    StartingBookingTime = DateTime.Now.AddHours(5),
                    EndingBookingTime =  DateTime.Now.AddHours(6),
                    BookingDate = System.DayOfWeek.Thursday,
                    TotalPaymentAmount = 200

                },new Booking
                {
                    SportName = "Futsal",
                    CourtName = "Court 1",
                    Username = "Fadel",
                    CenterName = "Champions Center",
                    StartingBookingTime = DateTime.Now,
                    EndingBookingTime =  DateTime.Now.AddHours(2),
                    BookingDate = System.DayOfWeek.Thursday,
                    TotalPaymentAmount = 250

                }
            };
        }


        public async Task AddBookingDataAsync()
        {
            try
            {
                foreach (var booking in Bookings)
                {
                    await client.Child("Bookings").PostAsync(new Booking()
                    {
                        SportName = booking.SportName,
                        CourtName = booking.CourtName,
                        Username = booking.Username,
                        CenterName = booking.CenterName,
                        StartingBookingTime = booking.StartingBookingTime,
                        EndingBookingTime = booking.EndingBookingTime,
                        BookingDate = booking.BookingDate,
                        TotalPaymentAmount = booking.TotalPaymentAmount
                    });
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }

        }
    }
}
