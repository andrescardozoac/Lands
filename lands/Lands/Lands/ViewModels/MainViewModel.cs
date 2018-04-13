using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    public class MainViewModel
    {

        #region ViewModels

        public LoginViewModel Login
        { get; set; }

        #endregion

        #region Contructs

        public MainViewModel()
        {
            this.Login = new LoginViewModel();
        }
        #endregion

    }
}
