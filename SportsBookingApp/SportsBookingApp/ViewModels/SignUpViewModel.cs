using SportsBookingApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SportsBookingApp.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {
        public SignUpViewModel()
        {
            SignUpCommand = new Command(async () => await SignUpCommandAsync());
            NavigateToSignInCommand = new Command(async () => await NavigateToSignInCommandAsync());


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
        private string _email;
        public string Email
        {
            set
            {
                this._email = value;
                OnpropertyChanged();
            }
            get
            {
                return this._email;
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


        public Command SignUpCommand { get; set; }
        public Command NavigateToSignInCommand { get; set; }

        /*

        public DelegateCommand SignUpCommand =>
            _signUpCommand ?? (_signUpCommand = new DelegateCommand(ExecuteSignUpCommand));

        public DelegateCommand NavigateToSignInCommand =>
            _navigateToSignInCommand ?? (_navigateToSignInCommand = new DelegateCommand(ExecuteNavigateToSignInCommand));
        */

        //async void ExecuteSignUpCommand();

        private async Task SignUpCommandAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var userService = new UserService();
                Result = await userService.RegisterUser(Username, Email, Password);
                if (Result)
                    await Application.Current.MainPage.DisplayAlert("Success", "User Registered", "OK");
                else
                    await Application.Current.MainPage.DisplayAlert("Error", "User already exists with this email", "OK");
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

        private async Task NavigateToSignInCommandAsync()
        {

            await Application.Current.MainPage.Navigation.PopModalAsync();
            // await _navigationService.GoBackAsync();
        }

    }
}
