

namespace Lands.ViewModels
{
    using Lands.Models;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class LandViewModel : BaseViewModel
    {

        

        #region Attributtes
        private ObservableCollection<Border> boders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion



        #region Properties


        public Land Land
            {

            get;
            set;


            }

        public ObservableCollection<Border> Borders
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.boders; }
            set
            {
                this.SetValue(ref this.boders,value);

            }
        }

        public ObservableCollection<Currency> Currencies
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.currencies; }
            set
            {
                this.SetValue(ref this.currencies, value);

            }
        }

        public ObservableCollection<Language> Languages
        {
            //Para refrescar las propiedaeds en tiempo de ejecucion mediante la clase BaseViewModel
            get { return this.languages; }
            set
            {
                this.SetValue(ref this.languages, value);

            }
        }


        #endregion


        private LandItemViewModel landItemViewModel;

        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBordes();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Land.Languages);
        }


        #region Methods

        private void LoadBordes()
        {
            this.Borders = new ObservableCollection<Border>();

            foreach(var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandList.
                    Where(l => l.Alpha3Code == border).FirstOrDefault();

                if (land != null)
                {

                    this.Borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,

                    });

                }

            }



        }

        #endregion
    }
}
