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
using System.Windows.Shapes;
using System.ComponentModel.Composition;
using System.Windows.Forms;
using Xuanyuan.Core;
using Microsoft.Practices.Prism.Regions;

namespace Xuanyuan.Shells
{
    /// <summary>
    /// Interaction logic for RM.xaml
    /// </summary>
    [Export("RM", typeof(Shell))]
    public partial class RM : Shell
    {
        public RM()
        {
            InitializeComponent();


            RegionManager.SetRegionName(contentCtrl, "Reference");

            Screen screen = Screen.AllScreens[0];

            this.Top = screen.WorkingArea.Y;
            this.Left = screen.WorkingArea.X;
            this.Width = screen.WorkingArea.Width;
            this.Height = screen.WorkingArea.Height;


        }
    }
}
