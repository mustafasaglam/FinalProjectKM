using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //yine interface erişim belirtecimizi public yaparız
    //Burada önceki derslerimizde de işlediğimiz gibi metodlarımızı tutacağız***
    public interface IProductDal:IEntityRepository<Product> //Artık IProductDal asen bir IEntityRepository sin dedik ve ona T tipindeki ilgili nesnesini veridk***
    {


        //--İlk öğrenim notları oku :) **---
        //Product Tablomuzu görmemiz için Entities i DataAccess layer a referans olarak eklememiz lazım. Projeye Sağ tık >Add>Project Reference
        //Normalde ışık üzerine tıklayıp Add Referane diyerek otomatik keleniyor ama sürümde Visual Studio da bug var eklemiyor bizde üsteki yöntem ile yani uzun yol ile ekliyoruz. Yani Dependencies bağımlılıklara ekliyoruz

        //*** Katmalnların hepsini birbine referans verme gibi bir işlem yapmıyoruz. İhtiyaç olduğund abu işlemleri yapacağız

        ////List<Product> GetAll();  // Tüm ürünleri çeken metodumuz

        ////void Add(Product product); //Product ekleme metodumuz, parametre olarak Product alıyor

        ////void Update(Product product); // Güncelleme işlemi için

        ////void Delete(Product product); // Silme işlemi için


        //interface metodları default public tir. ama interface in kendisi default public değildir biz elle veririrz

        //Yeni bir metod ekleyelim
        ////List<Product> GetByGategory(int categoryId);
    }
}
