using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;

namespace XAppFramework.Shared
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public virtual void Initialize() 
        {
            IsReady = true;
        }

        public bool IsReady { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged<T>(Expression<Func<T>> expression)
        {
            if (expression.Body.NodeType == ExpressionType.MemberAccess)
            {
                MemberExpression memberExp = expression.Body as MemberExpression;
                string memberName = memberExp.Member.Name;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(memberName));
                }
            }
        }
    }
}
