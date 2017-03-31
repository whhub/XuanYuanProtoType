using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace MyEnviroment.Platform.Common
{
    public static class IoC
    {
        public static Func<Type, string, object> GetInstance;

        public static T Get<T>()
        {
            return (T)GetInstance(typeof(T), null);
        }

        public static T Get<T>(string key)
        {
            return (T)GetInstance(null, key);
        }
    }
}
