using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors) //Methoinfo reflaction using e ekle.
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> //Git clasın ettirubute larını oku bul 
                (true).ToList(); // ve o attirubuteları bir listeye koy //To list system.ling çöz
            var methodAttributes = type.GetMethod(method.Name) //Git metodların attirubutelarını bul
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //Loglama için, otomatik olarak sistemdeki tüm logları dahil et demek. Eski yeni tüm metodları loglamayı default olarak aktif eder.Şimdilik loglama altyapısı yokken kapattık

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //Bu listeleri önceliğe göre geri dön
        }
    }

}
