﻿using System;
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

namespace Module.Views.PR
{
    /// <summary>
    /// Interaction logic for PRView.xaml
    /// </summary>
    [Export("PRView", typeof(Control))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class PRView : UserControl
    {
        public PRView()
        {
            InitializeComponent();
        }
    }
}
