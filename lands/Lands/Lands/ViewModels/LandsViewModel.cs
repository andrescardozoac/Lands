

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

        private ApiService apiservice;    

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
            this.LoadLands();
            this.apiservice = new ApiService();
        }

        #endregion

        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiservice.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if(!response.IsSuccess )
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept"
                    );

                var list = (List<Land>)response.Result;
                this.Lands = new ObservableCollection<Land>(list);

            }

        }

        #endregion

    }
}
