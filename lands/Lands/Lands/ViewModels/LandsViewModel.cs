

namespace Lands.ViewModels
{


    using System.Collections.ObjectModel;
    using Services;
    using Models;
    using Xamarin.Forms;
    using System.Collections.Generic;

    public class LandsViewModel : BaseViewModel //Hereda de BaseViewModel Para poder refrescar en Pantalla 
    {

        #region Services

        private ApiService apiService;    

        #endregion


        #region Atributtes
        private ObservableCollection<Land> lands; //Creamos una lista tipo ObservableCollection para pintar en un ListView de la clase Land
        #endregion

        #region Properties

        public ObservableCollection<Land> Lands
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.lands; }
            set
            {
                SetValue(ref this.lands, value);

            }
            #endregion




        }

        #region Contructor
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();
           
        }

        #endregion

        #region Methods
        private async void LoadLands()
        {
            var connection = await this.apiService.CheckConnection();

            if(!connection.IsSuccess)
            {

                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept"
                    );

                await Application.Current.MainPage.Navigation.PopAsync(); //Desapila, se devuelve un atras en codigo

                return;

            }

            var response = await this.apiService.GetList<Land> (
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if(!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept"
                    );
                return;


            }

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        }

        #endregion

    }
}
