

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


        #endregion


        private LandItemViewModel landItemViewModel;

        public LandViewModel(Land land)
        {
            this.Land = land;
            this.LoadBordes();
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
