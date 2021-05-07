using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SportsBookingApp.ViewModels
{
    public class AdminBookingHistoryViewModel : BaseViewModel
    {
        public AdminBookingHistoryViewModel()
        {

        }

        public ObservableCollection<Agenda> MyAgenda { get => GetAgenda(); }

        private ObservableCollection<Agenda> GetAgenda()
        {
            return new ObservableCollection<Agenda>
            {
                new Agenda { Topic = "Futsal Court 1", Duration = "07:30 AM - 11:30 AM", Money="RM 150", Color = "#B96CBD", Date = new DateTime(2020, 3, 23),
                    Bookings = new ObservableCollection<Bookings>{ new Bookings { Name = "Aziz", Time = "07:30 AM", Amount="RM 50" }, new Bookings { Name = "MD. Sabbir", Time = "08:30 AM", Amount = "RM 50" }, new Bookings { Name = "Faruk", Time = "10:30 AM", Amount = "RM 50" } } },

                new Agenda { Topic = "Futsal Court 2", Duration = "04:00 PM - 08:00 PM", Money="RM 300", Color = "#00C6AE", Date = new DateTime(2020, 3, 23),
                    Bookings = new ObservableCollection<Bookings>{ new Bookings { Name = "Mahdy", Time = "04:00 PM", Amount = "RM 100" }, new Bookings { Name = "Tahan", Time = "06:00 PM", Amount = "RM 150" }, new Bookings { Name = "Gerald", Time = "07:00 PM", Amount = "RM 50" } } },

            };
        }



        public class Agenda
        {
            public string Topic { get; set; }
            public string Money { get; set; }
            public string Duration { get; set; }
            public DateTime Date { get; set; }
            public ObservableCollection<Bookings> Bookings { get; set; }
            public string Color { get; set; }
        }

        public class Bookings
        {
            public string Name { get; set; }
            public string Time { get; set; }
            public string Amount { get; set; }
        }

    }
}
