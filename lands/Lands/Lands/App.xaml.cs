using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Lands
{ 
    using Xamarin.Forms; //Recomendacion Meter los Usign por dentro de los namespace (puedenir por dentro o por fuera)por que es mas facil copiar codigo entre clases -> por la ruta
    using Lands.Views;

	public partial class App : Application
	{
        #region CONSTRUCTOR
        public App() //contructor
        {
            InitializeComponent();

            this.MainPage = new NavigationPage( new LoginPage());
        }
        #endregion

        #region METODOS
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
