using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MyEnviroment.Platform.Common;

namespace MyEnvironment.Plugins.PluginThree
{
    [ViewModelAttr("PluginThreeMainViewModel", ViewModelName = "PluginThreeMainViewModel")]
    public class PluginThreeMainViewModel : ViewModelBase
    {
        [Import("Add",typeof(Func<int,int,int>))]
        private Func<int, int, int> _calculateCmdDelegate;

        public PluginThreeMainViewModel()
        {
            var catalog = new DirectoryCatalog(Environment.CurrentDirectory);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        private ICommand _calculateCmd;
        public ICommand CalculateCmd
        {
            get
            {
                return this._calculateCmd ??(this._calculateCmd =
                        new RelayCommand(() => { this.CalculateResult = this._calculateCmdDelegate(1, 2).ToString(); }));
            }
        }

        private string _calculateResult;
        public string CalculateResult
        {
            set { this._calculateResult = value; RaisePropertyChanged("CalculateResult"); }
            get { return this._calculateResult; }
        }
    }
}
