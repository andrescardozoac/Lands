

namespace Lands.ViewModels
{

    using Lands.Models;


    public class LandViewModel
    {

        #region Properties

        public Land Land
            {

            get;
            set;


            }


        #endregion


        private LandItemViewModel landItemViewModel;

        public LandViewModel(Land land)
        {
            this.Land = land;
        }
    }
}
