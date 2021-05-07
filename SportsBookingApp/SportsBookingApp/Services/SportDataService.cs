using Firebase.Database;
using SportsBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsBookingApp.Services
{
    public class SportDataService
    {
        FirebaseClient client;
        public SportDataService()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Sport>> GetSportsAsync()
        {
            var sports = (await client.Child("Sports").
                OnceAsync<Sport>()).
                Select(c => new Sport
                {
                    SportID = c.Object.SportID,
                    SportName = c.Object.SportName,
                    SportImage = c.Object.SportImage,
                    SportIcon = c.Object.SportIcon,
                }).ToList();

            return sports;
        }

    }

}
