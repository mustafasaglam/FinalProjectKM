using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolver.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Art�k bu k�s�mda diyoruzki .net senind efault Ioc yap�n� kullanmayaca��z. Biz kendi enjekte etti�imiz. Autofac yap�s�n� kullanca��z.

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            //**
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) //Autofac.Extension.DependencyInjection paketi ekle
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })
            //** bu iki y�ld�z aras�ndaki ks�m� biz yazd�k Yani autofac i kullan diyoruz

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>(); //Bu bize startup.cs deki Ioc ya�mz�� aya�a kald�r�yor.
                    
                });
    }
}
