using SportsBookingApp.Services;
using SportsBookingApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportsBookingApp.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel()
        {
            SignInCommandAsUser = new Command(async () => await SignInCommandAsUserAsync());
            SignInCommandAsAdmin = new Command(async () => await SignInCommandAsAdminAsync());
            NavigateToSignUpCommand = new Command(async () => await NavigateToSignUpCommandAsync());

        }

        private string _username;
        public string Username
        {
            set
            {
                this._username = value;
                OnpropertyChanged();
            }
            get
            {
                return this._username;
            }
        }

        private string _password;
        public string Password
        {
            set
            {
                this._password = value;
                OnpropertyChanged();
            }
            get
            {
                return this._password;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            set
            {
                this._isBusy = value;
                OnpropertyChanged();
            }
            get
            {
                return this._isBusy;
            }
        }

        private bool _result;
        public bool Result
        {
            set
            {
                this._result = value;
                OnpropertyChanged();
            }
            get
            {
                return this._result;
            }
        }


        public Command SignInCommandAsUser { get; set; }
        public Command SignInCommandAsAdmin { get; set; }
        public Command NavigateToSignUpCommand { get; set; }



        //await Application.Current.MainPage.Navigation.PushModalAsync(new ProductsView());
        /*
        private DelegateCommand _signInCommandAsUser;
        private DelegateCommand _signInCommandAsAdmin;
        private DelegateCommand _navigateToSignUpCommand;
        

        public DelegateCommand SignInCommandAsUser =>
            _signInCommandAsUser ?? (_signInCommandAsUser = new DelegateCommand(ExecuteSignInCommandAsUser));
        public DelegateCommand SignInCommandAsAdmin =>
            _signInCommandAsAdmin ?? (_signInCommandAsAdmin = new DelegateCommand(ExecuteSignInCommandAsAdmin));


        public DelegateCommand NavigateToSignUpCommand =>
            _navigateToSignUpCommand ?? (_navigateToSignUpCommand = new DelegateCommand(ExecuteNavigateToSignUpCommand));
        */

        //async void ExecuteSignInCommandAsUser();
        private async Task SignInCommandAsUserAsync()
        {

            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.LoginUser(Username, Password);
                if (Result)
                {
                    Preferences.Set("UserName", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new MainTabbedView());
                    // await _navigationService.NavigateAsync("/MainShell");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        private async Task SignInCommandAsAdminAsync()
        {

            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var centerService = new CenterService();
                Result = await centerService.LoginCenter(Username, Password);
                if (Result)
                {
                    Preferences.Set("CenterName", Username);
                    await Application.Current.MainPage.Navigation.PushModalAsync(new CenterTabbedView());
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "Invalid Username or Password", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }



        private async Task NavigateToSignUpCommandAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new SignUpView());
            // await _navigationService.NavigateAsync("SignUpView");
        }

    }
}
