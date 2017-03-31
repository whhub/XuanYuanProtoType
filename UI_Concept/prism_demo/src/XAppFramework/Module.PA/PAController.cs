using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using XAppFramework.Shared.Event;
using Microsoft.Practices.Prism.Regions;

namespace Module.PA
{
    [Export(typeof(PAController))]
    public class PAController
    {
        [Import("PA")]
        public Control View { get; set; }

        [Import]
        public PAViewModel ViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IRegionViewRegistry ViewRegistry { get; set; }

        public void Composite()
        {
            View.DataContext = ViewModel;
            ViewModel.Initialize();
            EventAggregator.GetEvent<AppReady>().Subscribe(OnAppReady);
            ViewRegistry.RegisterViewWithRegion("LeftMainRegion", () => { return View; });
            ViewRegistry.RegisterViewWithRegion("RightMainRegion", () => { return View; });
        }

        public void OnAppReady(AppReadyEventArgs args)
        {
            
        }
    }
}
