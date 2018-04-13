
namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;

    //Recomendacion Using por dentro del namespaces 

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;


    public class LoginViewModel
    {

        #region Properties

        public string Email { get; set; }

        public string  Password { get; set; }

        public bool IsRunning { get; set; }

        public bool IsRemembered { get; set; }

        #endregion

        #region Constructs

        public LoginViewModel()
        {
            this.IsRemembered = true;
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

        private void Login()
        {
            
        }


        #endregion

    }
}
