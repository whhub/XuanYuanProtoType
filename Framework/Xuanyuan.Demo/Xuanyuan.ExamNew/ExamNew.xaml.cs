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

namespace Xuanyuan.ExamNew
{
    /// <summary>
    /// Interaction logic for ExamNew.xaml
    /// </summary>
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ExamNew : UserControl
    {
        public ExamNew()
        {
            InitializeComponent();
        }


        [Import("ExamViewModel", typeof(NotificationObject))]
        public NotificationObject ViewModel
        {
            get { return this.DataContext as NotificationObject; }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
