using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBookingApp.Models
{
    public class Center
    {
        public string CenterEmail { get; set; }
        public string CenterPassword { get; set; }
        public string CenterName { get; set; }
        public string CenterImage { get; set; }
        public double CenterRating { get; set; }
        public string CenterPhone { get; set; }
        public int NoOfTotalSportsforCenter { get; set; }
        public int NoOfTotalCourtsforCenter { get; set; }
        public int CenterID { get; set; }
        public string CenterSports { get; set; }

    }

}
