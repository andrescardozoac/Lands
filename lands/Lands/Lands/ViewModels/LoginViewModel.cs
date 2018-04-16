
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;

    //Recomendacion Using por dentro del namespaces 

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {


        #region Atributes

        private string password;
        private bool isrunning;
        private bool isEnabled;

        #endregion


        #region Properties

        public string Email { get; set; }

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



        if (this.Email != "luisandrescardozo@gmail.com" || this.Password != "12345")
        {
            this.IsRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                "Email or Password Incorrect.",
                "Accept");
            this.Password = string.Empty;
            return;

        }

        this.IsRunning = false;
        this.IsEnabled = true;

        await Application.Current.MainPage.DisplayAlert(
                "OK",
                "Fuck yeahh",
                "Accept");
        return;


    }




    #endregion

}
}
