
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.Views;

    //Recomendacion Using por dentro del namespaces 

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Services;

    public class LoginViewModel : BaseViewModel
    {
        #region Services

        private ApiService apiService;



        #endregion

        #region Atributes
        private string email;
        private string password;
        private bool isrunning;
        private bool isEnabled;

        #endregion


        #region Properties

        public string Email
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.email; }
            set { SetValue(ref this.email, value); }

        }

        public string Password
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.password; }
            set { SetValue(ref this.password, value); }

        }


        public bool IsRunning
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.isrunning; }
            set { SetValue(ref this.isrunning, value); }
        }

        public bool IsRemembered { get; set; }

        public bool IsEnabled
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }

        #endregion

        #region Constructs

        public LoginViewModel()
        {

            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.isEnabled = true;


        }
        #endregion


        #region Commands

        public ICommand LoginCommand
        {
            get
            {

                return new RelayCommand(Login);

            }

        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Email",
                    "Accep");
                return;

            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "You must enter an Password",
                    "Accep");

                return;

            }

            this.IsRunning = true;
            this.IsEnabled = false;


            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");

            }

            var token = await this.apiService.GetToken(
                "http://landsapis.azurewebsites.net/",
                this.Email,
                this.Password);

            if (token == null)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Something was wrong, please try later",
                    "Accept");
                return;
            }

            if (string.IsNullOrEmpty(token.AccessToken))
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    token.ErrorDescription,
                    "Accept");
                this.Password = string.Empty;
                return;
            }

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.token = token;
            mainViewModel.Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());
        


            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;
}
            




    #endregion

}
}
