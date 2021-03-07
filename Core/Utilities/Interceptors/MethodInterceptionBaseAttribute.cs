using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)] //classlara ve metodlara uygulanabilir demek. Çoklu kullanılabilir ve inherit edilmiş classalrda da kullanılabilir.
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor //Kızaranları autofac injecte ettikten sonra çözelim
    {
        public int Priority { get; set; }  //öncelik durumu

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
