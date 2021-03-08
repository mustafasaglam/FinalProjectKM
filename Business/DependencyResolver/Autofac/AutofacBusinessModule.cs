using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule : Module //using outofac seçerek bu clasa sen bir Module den kalıtım alıyorsun diyoruz.
    {
        protected override void Load(ContainerBuilder builder) //Load metodunu override edelim. Yani uygulama ayağa kaldığında çalışırken bunları yap diyoruz.
        {
            //Bu kısım startup.cs içinde yaptıımız addSingleton a karşılık geliyor
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();// Yani diyoruz ki birisi senden Product service isterse ona git productmanager instance örneği ver.SingleInstance tek bir instance oluştur herkes onu kullansın demek. Yani 100 bin kullanıcılı sistemde 100 bin instance yerine 1 tane üretim herkese onu kullandırıyor.
            builder.RegisterType<EFProductDal>().As<IProductDal>().SingleInstance(); //buda yine 2.satıdaki Ef product dal isterse I productdal ver diyoruz.

            //Yani bu şekilde consructurda verip geçiyoruz, sürekli newlememeize gerek kalmıyor

            //Devamındaki yapılandırmaya hangiler ile çalışacaksak
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

          



            //Bu kısım sabit. Git bütün interfacelerı al ve aspectInterceptorSelector ile çalıştır demek için
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
