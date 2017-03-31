using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows;
using XAppFramework.Shared;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using XAppFramework.Shared.Event;

namespace Module.PA
{
    [Export("PAViewModel",typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PAViewModel : ViewModelBase
    {
        [Import]
        public ILogger Logger { get; set; }

        public void Initialize()
        {
            Logger.Log(LogType.DEV, LogLevel.INFO, "PAViewModel");
        }

        [Import]
        IRegionManager RegionMng { get; set; }

        [Import]
        IEventAggregator EventAggregator { get; set; }

        private DelegateCommand _gotoPRCmd;

        public DelegateCommand GotoPRCommand
        {
            get
            {
                return _gotoPRCmd ?? (_gotoPRCmd = new DelegateCommand(GotoPR));
            }
        }

        private void GotoPR()
        {
            RegionMng.RequestNavigate("LeftMainRegion", "Module.Views.PR.PRView");
            EventAggregator.GetEvent<PatientRegistered>().Publish(null);
        }
    }
}
