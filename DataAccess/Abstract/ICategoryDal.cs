using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Code Refactoring : Kod iyileştirme**

    public interface ICategoryDal:IEntityRepository<Category> // Artık ICategoryDal a sen bir IEntityRepository sin dedik ve ona T tipindeki ilgili nesnesini verdik**
    {


        //--İlk öğrenim notları oku :) **---
        //Metodlarımızı IProductDal içinden kopyaladık ve Product olan kısmı Category yaptık. Pratik olmalsı için :)
        //Tabi bunu her seferinde bu şekilde değiştirmektense Bu yapıyı Generic olarak kurabilirz. Daha önceki derslerde öğrendik.:) yani list<T> şeklinde. Bu yapının ismi Generic Repository Design Pattern- Generic Repository Tasatım Deseni
        
        //Ekis şekli > Yenisi IEntityRepository ile şekillenen yapıdır. bundan önceki ahlinde onu refere atmemeiştik**
        ////List<Category> GetAll();  // Tüm ürünleri çeken metodumuz

        ////void Add(Category category); //Product ekleme metodumuz, parametre olarak Product alıyor

        ////void Update(Category category); // Güncelleme işlemi için

        ////void Delete(Category category); // Silme işlemi için

        //////Yeni bir metod ekleyelim
        ////List<Category> GetByCategory(int categoryId);
        ///

    }
}
