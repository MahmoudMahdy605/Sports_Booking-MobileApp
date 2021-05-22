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
    public class CourtDataService
    {
        FirebaseClient client;
        public CourtDataService()
        {
            client = new FirebaseClient("https://demooo-fa47d-default-rtdb.firebaseio.com/");
        }

        public async Task<List<Court>> GetCourtItemsAsync()
        {
            var courts = (await client.Child("Courts").
                OnceAsync<Court>()).
                Select(f => new Court
                {
                    CourtID = f.Object.CourtID,
                    SportID = f.Object.SportID,
                    SportName = f.Object.SportName,
                    CourtName = f.Object.CourtName,
                    CourtPaymentTimeScale = f.Object.CourtPaymentTimeScale,
                    CourtPaymentCostScale = f.Object.CourtPaymentCostScale,
                    MaxReservationATime = f.Object.MaxReservationATime,
                    CenterName = f.Object.CenterName,

                    CourtImage = f.Object.CourtImage,


                    BookingMember = f.Object.BookingMember,
                    TotalRevenueForTheCourtPerDay = f.Object.TotalRevenueForTheCourtPerDay
                }).ToList();

            return courts;
        }

        public async Task<ObservableCollection<Court>> GetCourtsItemsBySportAsync(int sportID)
        {
            var CourtsItemsBySport = new ObservableCollection<Court>();
            var items = (await GetCourtItemsAsync()).Where(p => p.SportID == sportID).ToList();

            foreach (var item in items)
            {
                CourtsItemsBySport.Add(item);
            }

            return CourtsItemsBySport;
        }

        public async Task<ObservableCollection<Court>> GetLatestCourtsItemsAsync()
        {
            var LatestCourtsItems = new ObservableCollection<Court>();
            var items = (await GetCourtItemsAsync()).OrderByDescending(f => f.CourtID).Take(3);

            foreach (var item in items)
            {
                LatestCourtsItems.Add(item);
            }

            return LatestCourtsItems;
        }

        public async Task<ObservableCollection<string>> GetCourtsNamesBySportAndCenterAsync(string selectedCenterName, string selectedSportName)
        {
            var CourtsNamesBySportAndCenter = new ObservableCollection<String>();
            var items = (await GetCourtItemsAsync()).Where(p => p.CenterName == selectedCenterName).Where(p => p.SportName == selectedSportName).ToList();

            foreach (var item in items)
            {
                CourtsNamesBySportAndCenter.Add(item.CourtName);
            }

            return CourtsNamesBySportAndCenter;
        }

        public async Task<ObservableCollection<Court>> GetCourtsDetailsBySportAndCenterAsync(string selectedCenterName, string selectedSportName)
        {
            var CourtsDetailsBySportAndCenter = new ObservableCollection<Court>();
            var items = (await GetCourtItemsAsync()).Where(p => p.CenterName == selectedCenterName).Where(p => p.SportName == selectedSportName).ToList();

            foreach (var item in items)
            {
                CourtsDetailsBySportAndCenter.Add(item);
            }

            return CourtsDetailsBySportAndCenter;
        }

        public async Task<ObservableCollection<Court>> GetCourtDataByCenterAndCourtNamesAsync(string centername, string courtname)
        {
            
            var CourtDataByName = new ObservableCollection<Court>();
            var items = (await GetCourtItemsAsync()).Where(p => p.CenterName == centername).Where(p => p.CourtName == courtname).ToList();

            foreach (var item in items)
            {
                CourtDataByName.Add(item);
            }
            
            return CourtDataByName;
        }




    }

}
