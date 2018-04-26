

namespace Lands.ViewModels
{


    using System.Collections.ObjectModel;
    using Services;
    using Models;
    using Xamarin.Forms;
    using System.Collections.Generic;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Linq;

    public class LandsViewModel : BaseViewModel //Hereda de BaseViewModel Para poder refrescar en Pantalla 
    {

        #region Services

        private ApiService apiService;    

        #endregion


        #region Atributtes
        private ObservableCollection<LandItemViewModel> lands; //Creamos una lista tipo ObservableCollection para pintar en un ListView de la clase Land
        private bool isRefreshing;
        private string filter;
        private List<Land> landList;
        #endregion

        #region Properties

        public ObservableCollection<LandItemViewModel> Lands
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.lands; }
            set
            {
                SetValue(ref this.lands, value);

            }
        }

        public bool IsRefreshing 
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.isRefreshing; }
            set
            {
                SetValue(ref this.isRefreshing, value);

            }
        }

        public string Filter
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();

            }
        }



        #endregion


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
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if(!connection.IsSuccess)
            {
                this.IsRefreshing = false;
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
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept"
                    );
                return;


            }

            this.landList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(
            this.ToLoadItemViewModel());
            this.IsRefreshing = false;
        }

        #region Methods
        private IEnumerable<LandItemViewModel> ToLoadItemViewModel()
        {
            return this.landList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }

        #endregion
        #endregion


        #region Commands

        public ICommand RefreshCommand
        {
            get
            {

                return new RelayCommand(LoadLands);

            }
            
        }

        public ICommand SearchCommand
        {
            get
            {

                return new RelayCommand(Search);

            }

        }

        private void Search()
        {
            
            if(string.IsNullOrEmpty(this.Filter))
            {

                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLoadItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>(
                    this.ToLoadItemViewModel().Where
                    (l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                          l.Capital.ToLower().Contains(this.Filter.ToLower())
                    ));


            }

        }

        #endregion

    }
}
