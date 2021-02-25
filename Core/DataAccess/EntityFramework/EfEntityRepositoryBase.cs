using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //EntityFramework için bir reository base oluşturuyoruz
    public class EfEntityRepositoryBase<TEntity, TContext> :IEntityRepository<TEntity> //Temel Metodların implementasyonu,Bit t tipinde TEntity olarak
        where TEntity:class,IEntity, new() //Yine burada Generic constraint ile kısıtlıyoruz. Yani buraya gelecek parametre bir classtır, veritabanı nesnesidir ve newlenmesi gerekir
        where TContext:DbContext,new()  // Yanibu bir Dbcontext nesnesidir diyoruz ve newlenebilir olmalı diyoruz ve usingleri ekliyoruz**
        // Bana Tentity tipinde class ver, ve bana bir t tipinde bir context ver
    {

        public void Add(TEntity entity)
        {
            //using içeriisnde yazmamaıızın sebebi bu nesnenin işi bitince yani using dışına çıkınca c# Çöp temizleyici tarafından (Garbage Collector) hemen bellketen atılmasıdır. Bellek yönetimi için iyi bil kullanımdır.
            //Bunu yapmak yerine direkt northwindcontext i de newleyebilirz ama bu daha performanslı olur. Çünkü newleyince bellekte kalma süresi daha uzundur.**
            //using ile çalışma şekline IDisposable pattern implementation of c# denir.**
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); //Git eklenecek verirnin referansını bul
                addedEntity.State = EntityState.Added; //bu aslında eklenecek bir nesne
                context.SaveChanges(); //ve şimdi değişiklikleri kaydet.
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); //Git silinecek verirnin referansını bul
                deletedEntity.State = EntityState.Deleted; //bu aslında silinecek bir nesne
                context.SaveChanges(); //ve şimdi değişiklikleri kaydet.
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //burada tek data getirecek.
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); // buda bize filter parametresi ile eşleşen tek bir kayıt getirecektir.
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //GetAll için filtre verebilsin olarak ayarlamıştık. ama isterse vermeyedebilir çünkü default null dı
            using (TContext context = new TContext())
            {
                //gelen filtre null ise product tablosunun tamamını liste olarak getir. / Yani select * from products
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

                // return geriye dön filtre==null mı ? eğer nulll ise ilk kısım : sonra null değilse gelen filtre ile filtreleyerek getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); //Git güncellenecek verirnin referansını bul
                updatedEntity.State = EntityState.Modified; //bu aslında güncellenecek bir nesne
                context.SaveChanges(); //ve şimdi değişiklikleri kaydet.
            }
        }

    }
}
