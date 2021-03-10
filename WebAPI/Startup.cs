using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
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
            //Autofac bu noktada kulln�labilir �cretsiz bir IoC yap�s�d�r. .NET in default IOC yap�s�n�n yerine Autofac i yap�land�rma olarak ekleyece�iz.
            //AOP teknikleri Aspect oriented programing
            //Bu yap�land�rmay� ba�ka bir katmandada kullanabilmek i�in Bussiness �zerinde aya�a kald�r�yoruz.
            //Nugetten Autofac ve Autofac.Extras.DynamicProxy k�t�phanelerini entegre ediyruz.
            //Art�k biz .NEt in IoC yap�s�n� de�ilde kendi olu�turdu�umuz Autofac yap�s�n� kullanaca��z demek i�in program.cs de yar� yap�yoruz Buradaki kodlar�m�z�da tabiki kald�rt�yoruz. //** koydu�umuz kodlar



            //**services.AddSingleton<IProductService,ProductManager>(); //Bana arkaplanda bir referans olu�tur diyoruz. IoC i�in. Yani diyor ki constructr da IProductService istenirse git ProductManager newle ve ona ver demek, istenirse bunu kulland�r.
            //Yukar�daki Ioc config e ek olarak IProductDal istenirse EfProductDal ver diyoruz. Bunu demez isek yine hata verecektir.
            //**services.AddSingleton<IProductDal, EFProductDal>();

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //Bunu hoca ekledi ama gerek yok ��nk� AutofacBusinessModule den set eiliyor zaten.

            //art�k Auth i�lemleri i�in bu jwt yap�s�n� kullan demi� oluyoruz
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //nuget jwtbearer y�kle

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) //bu if jwt hatalar� vs de detayl� g�rmek i�indi.
            {
                IdentityModelEventSource.ShowPII = true;
            }


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();  //bunu biz ekledik. Auth i�lemi i�in. Bu yap�n�n tamma�na middleware denir

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
