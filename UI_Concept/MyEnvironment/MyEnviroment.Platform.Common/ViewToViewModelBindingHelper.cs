using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight;

namespace MyEnviroment.Platform.Common
{
    public class ViewToViewModelBindingHelper
    {
        public const  string ViewToViewModelBindingPatternPropertyName = "ViewToViewModelBindingPatternPropertyName";

        public static readonly DependencyProperty ViewToViewModelBindingPatternProperty = DependencyProperty.RegisterAttached(
            ViewToViewModelBindingPatternPropertyName,
            typeof(string),
            typeof(ViewToViewModelBindingHelper),
            new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender, OnViewToViewModelBindingPatternPropertyChanged)
            );

        public static string GetViewToViewModelBindingPatternProperty(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(ViewToViewModelBindingPatternProperty);
        }

        public static void SetViewToViewModelBindingPatternProperty(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(ViewToViewModelBindingPatternProperty, value);
        }

        private static void OnViewToViewModelBindingPatternPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            var viewToViewModelBindingPattern = args.NewValue as string;
            var viewToViewModelBindingPatternArray = viewToViewModelBindingPattern.Split(';');
            var viewInstance = IoC.Get<FrameworkElement>(viewToViewModelBindingPatternArray[0]);
            var viewModelInstance = IoC.Get<ViewModelBase>(viewToViewModelBindingPatternArray[1]);
            viewInstance.DataContext = viewModelInstance;
            (dependencyObject as ContentControl).Content = viewInstance;
        }
    }
}
