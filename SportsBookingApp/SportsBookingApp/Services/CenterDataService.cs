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
    public class CenterService
    {
        FirebaseClient client;

        public CenterService()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
        }

        public async Task<bool> IsCenterExists(string email)
        {
            var center = (await client.Child("Centers").OnceAsync<Center>()).Where(u => u.Object.CenterEmail == email).FirstOrDefault();

            return (center != null);
        }


        public async Task<bool> LoginCenter(string uname, string passwd)
        {
            var center = (await client.Child("Centers")
                .OnceAsync<Center>()).Where(u => u.Object.CenterName == uname)
                .Where(u => u.Object.CenterPassword == passwd).FirstOrDefault();

            return (center != null);
        }

        public async Task<List<Center>> GetCenterItemsAsync()
        {
            var centers = (await client.Child("Centers").
                OnceAsync<Center>()).
                Select(f => new Center
                {
                    CenterID = f.Object.CenterID,
                    CenterEmail = f.Object.CenterEmail,
                    CenterImage = f.Object.CenterImage,
                    CenterPassword = f.Object.CenterPassword,
                    CenterPhone = f.Object.CenterPhone,
                    CenterRating = f.Object.CenterRating,
                    NoOfTotalCourtsforCenter = f.Object.NoOfTotalCourtsforCenter,
                    CenterName = f.Object.CenterName,
                    NoOfTotalSportsforCenter = f.Object.NoOfTotalSportsforCenter,
                    CenterSports = f.Object.CenterSports,
                    CenterLatitude = f.Object.CenterLatitude,
                    CenterLongitude = f.Object.CenterLongitude
                }).ToList();

            return centers;
        }




        public async Task<ObservableCollection<Center>> GetCenterItemsBySportAsync(string sportName)
        {

            var CentersItemsBySport = new ObservableCollection<Center>();
            var items = (await GetCenterItemsAsync()).Where(p => p.CenterSports.Contains(sportName)).ToList();

            foreach (var item in items)
            {
                CentersItemsBySport.Add(item);
            }

            return CentersItemsBySport;
        }



        /*
        public async Task<ObservableCollection<Center>> GetCenterItemsBySportAsync(int sportID)
        {

            var items = (await GetCenterItemsAsync()).Where(p => p.CenterName.Contains(sportName)).ToList();

            
            var CentersItemsBySport = new ObservableCollection<Court>();

            var CourtsBySport = await new CourtDataService().GetCourtsItemsBySportAsync(sportID);
            var CentersNames;
            foreach (var item in CourtsBySport)
            {
                CentersNames.Add(item);
            }

            var items = (await GetCenterItemsAsync()).Where(p => p.SportID == sportID).ToList();

            foreach (var item in items)
            {
                CentersItemsBySport.Add(item);
            }

            return CentersItemsBySport;
            
        }*/
    }

}
