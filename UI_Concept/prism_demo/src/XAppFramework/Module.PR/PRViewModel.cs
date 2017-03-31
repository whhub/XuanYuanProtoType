using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using XAppFramework.Shared;

namespace Module.PR
{
    [Export("PRViewModel", typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class PRViewModel : ViewModelBase
    {
        [Import]
        IRegionManager RegionMng{get;set;}

        private DelegateCommand _gotoPACmd;

        public DelegateCommand GotoPACommand
        {
            get
            {
                return _gotoPACmd ?? (_gotoPACmd = new DelegateCommand(GotoPA));
            }
        }

        private void GotoPA()
        {
            RegionMng.RequestNavigate("LeftMainRegion","PAView");
        }
    }
}
