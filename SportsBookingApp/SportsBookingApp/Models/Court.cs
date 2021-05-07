using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBookingApp.Models
{
    public class Court
    {
        public string CenterName { get; set; }
        public string SportName { get; set; }
        public int SportID { get; set; }
        public int CourtID { get; set; }
        public string CourtName { get; set; }
        public int MaxReservationATime { get; set; }
        public string CourtPaymentTimeScale { get; set; }
        public double CourtPaymentCostScale { get; set; }

    }

}
