using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;
using Xuanyuan.Core;

namespace Xuanyuan.Exam
{
    /// <summary>
    /// Interaction logic for Exam.xaml
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class Exam : UserControl
    {

        [ImportingConstructor]
        public Exam([Import("ExamViewModel", typeof(NotificationObject))]NotificationObject viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }

        [Import]
        public ILogger Logger
        {
            get { return _logger; }
            set { _logger = value;
            ///to set
            }
        }
        private ILogger _logger;


        //[Import("ExamViewModel", typeof(NotificationObject))]
        //public NotificationObject ViewModel
        //{
        //    get { return this.DataContext as NotificationObject; }
        //    set { 
        //        this.DataContext = value;
        //    }
        //}
    }
}
