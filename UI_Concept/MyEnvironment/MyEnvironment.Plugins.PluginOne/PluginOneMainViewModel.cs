using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyEnviroment.Platform.Common;

namespace MyEnvironment.Plugins.PluginOne
{
    [ViewModelAttr("PluginOneMainViewModel", ViewModelName = "PluginOneMainViewModel")]
    public class PluginOneMainViewModel : ViewModelBase
    {
        [Import("GetPluginName",typeof(Func<string>))]
        private Func<string> _pluginNameGetterDelegate;

        public PluginOneMainViewModel()
        {
            var catalog = new DirectoryCatalog(Environment.CurrentDirectory);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private ICommand _getPluginNameCmd;
        public ICommand GetPluginNameCmd
        {
            get
            {
                return this._getPluginNameCmd ?? new RelayCommand(() =>
                                                                      {
                                                                          this.PluginName =this._pluginNameGetterDelegate();
                                                                          Thread thread = new Thread(() =>
                                                                          {
                                                                              var tempWindow = new StartUper<Window>();
                                                                              tempWindow.Window.Show();
                                                                              System.Windows.Threading.Dispatcher.Run();
                                                                                    });
                                                                          thread.SetApartmentState(ApartmentState.STA);
                                                                          thread.Start();
                                                                     
                                                                      });
            }
        }
     
        private string _pluginName;
        public string PluginName
        {
            get
            {   
                return this._pluginName;
            }

            set
            {
                this._pluginName = this._pluginNameGetterDelegate();
                RaisePropertyChanged("PluginName");
            }

        }

    }


}
