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
    public class AddCourtData
    {
        FirebaseClient client;
        public List<Court> Courts { get; set; }

        public AddCourtData()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
            Courts = new List<Court>()
            {
                new Court
                {
                    CourtID = 1,
                    SportID = 1,
                    SportName = "Ping Pong",
                    CourtName = "Table 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 30,
                    CenterName = "Champions Center"
                },new Court
                {
                    CourtID = 2,
                    SportID = 1,
                    SportName = "Ping Pong",
                    CourtName = "Table 2",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 30,
                    CenterName = "Champions Center"
                },new Court
                {
                    CourtID = 1,
                    SportID = 1,
                    SportName = "Ping Pong",
                    CourtName = "Table 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 35,
                    CenterName = "Stars Center"
                },new Court
                {
                    CourtID = 1,
                    SportID = 2,
                    SportName = "Futsal",
                    CourtName = "Court 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 110,
                    CenterName = "BBC Futsal Center"
                },new Court
                {
                    CourtID = 2,
                    SportID = 2,
                    SportName = "Futsal",
                    CourtName = "Court 2",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 110,
                    CenterName = "BBC Futsal Center"
                },new Court
                {
                    CourtID =3,
                    SportID = 2,
                    SportName = "Futsal",
                    CourtName = "Court 3",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 110,
                    CenterName = "BBC Futsal Center"
                },new Court
                {
                    CourtID = 1,
                    SportID = 2,
                    SportName = "Futsal",
                    CourtName = "Court 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 100,
                    CenterName = "Champions Center"
                },new Court
                {
                    CourtID = 2,
                    SportID = 2,
                    SportName = "Futsal",
                    CourtName = "Court 2",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 100,
                    CenterName = "Champions Center"
                },new Court
                {
                    CourtID = 1,
                    SportID = 3,
                    SportName = "Badminton",
                    CourtName = "Court 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 40,
                    CenterName = "Stars Center"
                },new Court
                {
                    CourtID = 2,
                    SportID = 3,
                    SportName = "Badminton",
                    CourtName = "Court 2",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 40,
                    CenterName = "Stars Center"
                },new Court
                {
                    CourtID = 1,
                    SportID = 4,
                    SportName = "Gym",
                    CourtName = "Hall 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =15,
                    CourtPaymentCostScale = 5,
                    CenterName = "Stars Center"
                },new Court
                {
                    CourtID = 1,
                    SportID = 5,
                    SportName = "Basketball",
                    CourtName = "Court 1",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 100,
                    CenterName = "Champions Center"
                },new Court
                {
                    CourtID = 2,
                    SportID = 5,
                    SportName = "Basketball",
                    CourtName = "Court 2",
                    CourtPaymentTimeScale = "Hour",
                    MaxReservationATime =1,
                    CourtPaymentCostScale = 100,
                    CenterName = "Champions Center"
                }
            };
        }

        public async Task AddCourtDataAsync()
        {
            try
            {
                foreach (var court in Courts)
                {
                    await client.Child("Courts").PostAsync(new Court
                    {
                        CourtID = court.CourtID,
                        SportID = court.SportID,
                        SportName = court.SportName,
                        CourtName = court.CourtName,
                        CourtPaymentTimeScale = court.CourtPaymentTimeScale,
                        MaxReservationATime = court.MaxReservationATime,
                        CourtPaymentCostScale = court.CourtPaymentCostScale,
                        CenterName = court.CenterName

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
