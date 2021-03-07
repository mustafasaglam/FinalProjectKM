using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //******// Burdan itibaren biz ekledik // Bu yapýyý biz AutoFac,Ninject,LightÝnject,DryÝnject gibi yapýlara taþýyacaðýz. Yani .NET içinde Ioc yapýsý yokken bu yapýyý sunuyordu.
            //Autofac bu noktada kullnýlabilir ücretsiz bir IoC yapýsýdýr. .NET in default IOC yapýsýnýn yerine Autofac i yapýlandýrma olarak ekleyeceðiz.
            //AOP teknikleri Aspect oriented programing
            //Bu yapýlandýrmayý baþka bir katmandada kullanabilmek için Bussiness üzerinde ayaða kaldýrýyoruz.
            //Nugetten Autofac ve Autofac.Extras.DynamicProxy kütüphanelerini entegre ediyruz.
            //Artýk biz .NEt in IoC yapýsýný deðilde kendi oluþturduðumuz Autofac yapýsýný kullanacaðýz demek için program.cs de yarý yapýyoruz Buradaki kodlarýmýzýda tabiki kaldýrtýyoruz. //** koyduðumuz kodlar
            


            //**services.AddSingleton<IProductService,ProductManager>(); //Bana arkaplanda bir referans oluþtur diyoruz. IoC için. Yani diyor ki constructr da IProductService istenirse git ProductManager newle ve ona ver demek, istenirse bunu kullandýr.
            //Yukarýdaki Ioc config e ek olarak IProductDal istenirse EfProductDal ver diyoruz. Bunu demez isek yine hata verecektir.
            //**services.AddSingleton<IProductDal, EFProductDal>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
