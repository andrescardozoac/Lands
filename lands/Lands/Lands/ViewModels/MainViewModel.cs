using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    public class MainViewModel
    {

        #region ViewModels

        public LoginViewModel Login
        {
            get;
            set;
        }

        public LandsViewModel Lands
        {
            get;
            set;

        }

        #endregion

        #region Contructs

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion

        #region Singleton 
        //El Patron Singleton Nos permite poder hacer un llamado de la mainViewModel desde cualquier clase sin necesidad de instanciar otra main view model
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {

                return new MainViewModel();

            }
            return instance;
        }

        #endregion

    }
}
