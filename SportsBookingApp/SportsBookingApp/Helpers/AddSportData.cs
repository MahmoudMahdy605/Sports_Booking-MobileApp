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
    public class AddSportData
    {
        FirebaseClient client;
        public List<Sport> Sports { get; set; }

        public AddSportData()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
            Sports = new List<Sport>()
            {
                new Sport
                {
                    SportID = 1,
                    SportName = "Ping Pong",
                    SportImage = "ping_pong_img.png",
                    SportIcon = "ping_pong_75.png",
                },new Sport
                {
                    SportID = 2,
                    SportName = "Futsal",
                    SportImage = "futsal_img.png",
                    SportIcon = "futsal_75.png",
                },new Sport
                {
                    SportID = 3,
                    SportName = "Badminton",
                    SportImage = "badminton_img.png",
                    SportIcon = "badminton_75.png",
                },new Sport
                {
                    SportID = 4,
                    SportName = "Gym",
                    SportImage = "gym_img.png",
                    SportIcon = "gym_75.png",
                },new Sport
                {
                    SportID = 5,
                    SportName = "Basketball",
                    SportImage = "basketball_img.png",
                    SportIcon = "basketball_75.png",
                }
            };

        }

        public async Task AddSportDataAsync()
        {
            try
            {
                foreach (var sport in Sports)
                {
                    await client.Child("Sports").PostAsync(new Sport()
                    {
                        SportID = sport.SportID,
                        SportName = sport.SportName,
                        SportImage = sport.SportImage,
                        SportIcon = sport.SportIcon,
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
