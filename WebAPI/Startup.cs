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

            //******// Burdan itibaren biz ekledik // Bu yap�y� biz AutoFac,Ninject,Light�nject,Dry�nject gibi yap�lara ta��yaca��z. Yani .NET i�inde Ioc yap�s� yokken bu yap�y� sunuyordu.
            

            services.AddSingleton<IProductService,ProductManager>(); //Bana arkaplanda bir referans olu�tur diyoruz. IoC i�in. Yani diyor ki constructr da IProductService istenirse git ProductManager newle ve ona ver demek, istenirse bunu kulland�r.
            //Yukar�daki Ioc config e ek olarak IProductDal istenirse EfProductDal ver diyoruz. Bunu demez isek yine hata verecektir.
            services.AddSingleton<IProductDal, EFProductDal>();

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
