using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.InfraStructure
{
    using ViewModels;

    public class InstanceLocator
    {

        #region Properties

        public MainViewModel Main

        { get;

          set; }


        #endregion


        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }


    }
}
