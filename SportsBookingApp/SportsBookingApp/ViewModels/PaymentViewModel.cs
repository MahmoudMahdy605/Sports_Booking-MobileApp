using System;
using System.Collections.Generic;
using System.Text;

namespace SportsBookingApp.ViewModels
{
    public class PaymentViewModel : BaseViewModel
    {
        public PaymentViewModel(DateTime bookingDate)
        {

            BookingDate = bookingDate;
        }

        private DateTime _BookingDate;

        public DateTime BookingDate
        {
            set
            {
                _BookingDate = value;
                OnpropertyChanged();
            }
            get
            {
                return _BookingDate;
            }
        }
    }
}
