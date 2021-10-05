using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //atributlardan payp | - bu adlanir ..allowmultiple bu atributu birden cox istifade ede bileerem hem veritabanina loglasin hem de dosyaya loglasin istifade etmek olar atributlarda
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
