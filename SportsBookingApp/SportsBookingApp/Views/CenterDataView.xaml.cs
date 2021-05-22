using SportsBookingApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportsBookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CenterDataView : ContentPage
    {

        CenterDataViewModel asm;

        string c = Preferences.Get("CenterName", String.Empty);

        public CenterDataView()
        {
            InitializeComponent();

            asm = new CenterDataViewModel();
            this.BindingContext = asm;
        }

        private void ViewData_Clicked(object sender, EventArgs e)
        {

            asm = new CenterDataViewModel(c, StartingBookingDate.Date, EndingBookingDate.Date);
            this.BindingContext = asm;
        }
    }
}