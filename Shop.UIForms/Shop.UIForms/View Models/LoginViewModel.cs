namespace Shop.UIForms.View_Models
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(Login);

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "you must enter an email.",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                "Error",
                "you must enter a password.",
                "Accept");
                return;
            }

            await Application.Current.MainPage.DisplayAlert(
            "Ok",
            "Fuct yeah!!!",
            "Accept");
        }
    }
}
