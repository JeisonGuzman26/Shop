namespace Shop.UIForms.View_Models
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using View;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(this.Login);

        public LoginViewModel()
        {
            this.Email = "guzmojeison@gmail.com";
            this.Password = "123456";
        }
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

            if (!this.Email.Equals("guzmojeison@gmail.com") || !this.Password.Equals("123456"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Incorrect user or password",
                    "Accept");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //"Ok",
            //"Fuct yeah!!!",
            //"Accept");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
