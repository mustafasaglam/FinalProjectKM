using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Context Nesnesi Db Tabloları ile Proje Class larını bağlamak için kullanılır. ve DbContext sınıfından miras alır. Ve using e Ef.Core eklenir. (Entit Framework core.SqlServer Tüm Ef süürmleri ile aynı içeriği sağlar.**)
    public class NorthwindContext:DbContext
    {
        //override yazıp onconfigure tıklanır. Ve bize projemizin hangi veritabanına bağlanacağını belirtiriz.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Northwind;Trusted_Connection=true"); //SqlServer ı kullanacağız diyoruz. Ve nasıl bağlanacağımızı belirtiyorz "" içinde aslında bir connection string yazıyoruz.Önce başına @ koyarız. Çünkü ters slash kullanımını \ algıla demek oluyor.
            //Sql sunucumuzda yani localimizde NorthwindKampDB diye olan northwind veritabnına bağlanmasını istedik.
            //tusted connection yani güvenli olduğu belirtiriz. Ancak uzak sunucularda server bir ip ve kullanıcı adı şifre olur.

        }

        //Bu kısımdada projemizdeki nesnelerimizin veritabanında hangi tabloya denk geleceğini belirtiyoruz. Yani mapping işlemi.

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    }
}
