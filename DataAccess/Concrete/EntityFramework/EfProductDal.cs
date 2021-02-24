using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {


        //öğrenirken liste doldurmak için yapmıştık ilerleyince yorum satırı yaptım**
        ////List<Product> _products;

        ////public EFProductDal()
        ////{
        ////    _products = new List<Product>
        ////    {
        ////        new Product{ProductName="Kulaklık"},
        ////        new Product{ProductName="Hoparlör"}
        ////    };
        ////}

        ////public List<Product> GetAll() kendimiz test için elle yazmıştık***
        ////{
        ////    return _products;
        ////}
        

        //Son implemente hali

        public void Add(Product entity)
        {
            //using içeriisnde yazmamaıızın sebebi bu nesnenin işi bitince yani using dışına çıkınca c# Çöp temizleyici tarafından (Collector) hemen bellketen atılmasıdır. Bellek yönetimi için iyi bil kullanımdır.
            //Bunu yapmak yerine direkt northwindcontext i de newleyebilirz ama bu daha performanslı olur. Çünkü newleyince bellekte kalma süresi daha uzundur.**
            //using ile çalışma şekline IDisposable pattern implementation of c# denir.**
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity); //Git eklenecek verirnin referansını bul
                addedEntity.State = EntityState.Added; //bu aslında eklenecek bir nesne
                context.SaveChanges(); //ve şimdi değişiklikleri kaydet.
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity); //Git silinecek verirnin referansını bul
                deletedEntity.State = EntityState.Deleted; //bu aslında silinecek bir nesne
                context.SaveChanges(); //ve şimdi değişiklikleri kaydet.
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //burada tek data getirecek.
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter); // buda bize filter parametresi ile eşleşen tek bir kayıt getirecektir.
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //GetAll için filtre verebilsin olarak ayarlamıştık. ama isterse vermeyedebilir çünkü default null dı
            using (NorthwindContext context = new NorthwindContext())
            {
                //gelen filtre null ise product tablosunun tamamını liste olarak getir. / Yani select * from products
                return filter == null ? context.Set<Product>().ToList() 
                    : context.Set<Product>().Where(filter).ToList();

                // return geriye dön filtre==null mı ? eğer nulll ise ilk kısım : sonra null değilse gelen filtre ile filtreleyerek getir
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity); //Git güncellenecek verirnin referansını bul
                updatedEntity.State = EntityState.Modified; //bu aslında güncellenecek bir nesne
                context.SaveChanges(); //ve şimdi değişiklikleri kaydet.
            }
        }
    }
}
