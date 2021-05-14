using SportsBookingApp.Models;
using SportsBookingApp.Services;
using SportsBookingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportsBookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookingView : ContentPage
    {
        //public ObservableCollection<Booked> CollectDetails { get; set; }


        BookingViewModel asm;

        Center c;
        string s;

        public BookingView(Center center, string sportname)
        {
            InitializeComponent();


            c = center;
            s = sportname;

            SelectedStartingBookingTime.Time = System.DateTime.Now.TimeOfDay;
            SelectedEndingBookingTime.Time = SelectedStartingBookingTime.Time;

            asm = new BookingViewModel(center, sportname);
            this.BindingContext = asm;

            /*
            this.BindingContext = this;
            
            CollectDetails = new ObservableCollection<Booked>
            {
                new Booked {Shomoy="4:00 PM-5:00 PM"},
                new Booked {Shomoy="7:00 PM-8:00 PM"},
                new Booked {Shomoy="10:00 AM-11:30 AM"},
            };
            */

        }
        
        private async void SelectedBookingDate_DateSelected(object sender, DateChangedEventArgs e)
        {

            // asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date);

            //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString());

            asm = new BookingViewModel(c, s);
            //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date.DayOfWeek);
            
            this.BindingContext = asm;
                
            
        }

        private void CheckAvailability_Clicked(object sender, EventArgs e)
        {
            asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date);

            SelectedCourt.SelectedItem = SelectedCourt.SelectedItem;
            this.BindingContext = asm;
        }



        private async void ButtonBook_Clicked(object sender, EventArgs e)
        {
            // var checkconflictbooking = VerifyAvailabilityOfBookingSlotAsync(c.CenterName, SelectedBookingDate.Date.DayOfWeek, SelectedCourt.SelectedItem.ToString(), SelectedStartingBookingTime.Time, SelectedEndingBookingTime.Time);




            if (VerifyTimeSequence (SelectedStartingBookingTime.Time, SelectedEndingBookingTime.Time) == true )
            {
                if(VerifyWorkingTime(SelectedStartingBookingTime.Time, SelectedEndingBookingTime.Time) == true)
                {

                    try
                    {
                        bool Noconflictexists = await VerifyAvailabilityOfBookingSlotAsync(c.CenterName, SelectedBookingDate.Date, SelectedCourt.SelectedItem.ToString(), SelectedStartingBookingTime.Time, SelectedEndingBookingTime.Time);
                        
                        // SelectedCourt.SelectedItem is nullllllllllllllllll, why ;
                        if (Noconflictexists == true)
                        {

                            await Application.Current.MainPage.DisplayAlert("Nice", " booking time is not conflicting", "OK"); // successful booking time


                            await Navigation.PushModalAsync(new PaymentView());
                            // navigate to paymentview with passing parameters;
                            // navigate to paymentview with passing parameters;
                            // navigate to paymentview with passing parameters;
                            // navigate to paymentview with passing parameters;
                            // navigate to paymentview with passing parameters;

                        }
                        else await Application.Current.MainPage.DisplayAlert("Conflict booking", " booking time is conflicting", "Select another availabile time"); //  booking time already exists;

                    }
                    catch 
                    {

                        await Application.Current.MainPage.DisplayAlert("Error for conflict booking", "e.Message", "OK");
                    }
                    
                   
                }
                else await Application.Current.MainPage.DisplayAlert("Sorry", " we're only open from 8AM to 2 AM", "OK");

                
                /*
                Control1Output.Text = string.Format("Thank you. Your appointment is set for {0}.",
                   arrivalTimePicker.Time.ToString());
                */
            }else
            {
                await Application.Current.MainPage.DisplayAlert("Error", " Ending booking time is same / preceding Starting booking time", "OK");
            }
        }

        private bool VerifyWorkingTime(TimeSpan startingtime, TimeSpan endingtime)
        {

            // Set open (8 AM) and close (2 AM) times. 
            TimeSpan openTime = new TimeSpan(8, 0, 0);
            TimeSpan closeTime = new TimeSpan(2, 0, 0);

            /*
            Application.Current.MainPage.DisplayAlert("endingtime ", endingtime.ToString(), "OK");
            Application.Current.MainPage.DisplayAlert("startingtime ", startingtime.ToString(), "OK");
            Application.Current.MainPage.DisplayAlert("openTime", openTime.ToString(), "OK");
            Application.Current.MainPage.DisplayAlert("closeTime", closeTime.ToString(), "OK");
            */

            if ((startingtime >= openTime || startingtime <= closeTime) && (endingtime >= openTime || endingtime <= closeTime))
            {
                return true; // Open 
            }
            return false; // Closed 
        }
        private bool VerifyTimeSequence(TimeSpan startingtime, TimeSpan endingtime)
        {


            if ((startingtime < endingtime))
            {
                return true; // startingtime is before endingtime 
            }
            return false; // startingtime is not before endingtime  
        }
        
        private async Task<bool> VerifyAvailabilityOfBookingSlotAsync( string centername, DateTime bookingdate, string courtname, TimeSpan startingtime, TimeSpan endingtime)
        {
            var ConfilctBookingExists = await new BookingDataService().CheckForConflictBookingAsync (centername, bookingdate, courtname, startingtime, endingtime);
            
            if (ConfilctBookingExists == true) return true;
            else return false;
        }

        /*
        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;


        try
        {
            if (selectedIndex != -1)
            {
                Application.Current.MainPage.DisplayAlert("ok", "index not negative", "OK");

                asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date.DayOfWeek);
                this.BindingContext = asm;
            }

        }
        catch (Exception ex)
        {
            Application.Current.MainPage.DisplayAlert("error", ex.Message, "OK");
        }

            
        Picker p = new Picker();
        p = (Picker)sender;

        try
        {
            if ((Picker)sender.SelectedIndex >= 0)
            {
                Application.Current.MainPage.DisplayAlert("ok", "index not negative", "OK");
                //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date);

                asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString());
                this.BindingContext = asm;
            }
        }
        catch (Exception ex)
        {
            Application.Current.MainPage.DisplayAlert("error", ex.Message, "OK");
        }



        //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString(), SelectedBookingDate.Date);

        //asm = new BookingViewModel(c, s, SelectedCourt.SelectedItem.ToString());
        //this.BindingContext = asm;

        var data = await new CourtDataService().GetCourtDataByNameAsync(SelectedCourt.SelectedItem.ToString());
        //var asdf = await new CourtDataService().GetCourtDataByNameAsync.(SelectedCourt.SelectedItem.ToString());
        // await Court asdf = new CourtDataService.(SelectedCourt.SelectedItem.ToString());

        CourtPaymentCostScale.Text = data. ;
        CourtPaymentTimeScale.Text = ;

        asm = new BookingViewModel(center, sportname, SelectedCourt.Title, SelectedBookingDate.Date);
            
        }
    */


    }

    /*
    public class Booked
    {
        public string Shomoy { get; set; }

    }
    */

}