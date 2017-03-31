using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel;
using Microsoft.Practices.Prism.Events;
using XAppFramework.Shared.Event;
using XAppFramework.Shared;

namespace Module.Ref
{
    [Export("RefViewModel",typeof(ViewModelBase))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    class RefViewModel : ViewModelBase, INotifyPropertyChanged
    {
        double _imgHeight;

        [Import]
        IEventAggregator EventAggregator { get; set; }

        public double ImageHeight
        {
            get { return _imgHeight; }
            set
            {
                _imgHeight = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("ImageHeight"));
            }
        }

        public override void Initialize()
        {
            ImageHeight = 512;
            EventAggregator.GetEvent<PatientRegistered>().Subscribe(OnPatientRegisterd);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _up = false;
        private void OnPatientRegisterd(PatientRegisteredArgs args)
        {
            if (_up)
                ImageHeight = ImageHeight * 2.0;
            else
                ImageHeight = ImageHeight / 2.0;
            if (ImageHeight > 1024) _up = false;
            if (ImageHeight < 1) _up = true;

        }
    }
}
