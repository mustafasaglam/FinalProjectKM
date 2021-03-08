using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //public yapalım. Bunlarda iş katmanında kullanacağımız iş katmanları
    // Bussiness Katmanımıza DataAccess ve Entities projelermizi project refrens olarak ekleriz.*** Çünkü busines hem entities hemde dataAccess katmanlarını kullanır.
    public interface IProductService
    {
        //Liste dönenleride IDataResult yaptık
        IDataResult<List<Product>> GetAll(); // Tüm kategorileri getir.

        IDataResult<List<Product>> GetAllByCategoryId(int id); //Kategori id ye göre ürünleri getir**

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max); //Örneğin şu fiyat aralığında olan ürünleri getir diyeceğiz

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        
        IDataResult<Product> GetById(int productId); //Tek başına 1 kayıt getirecek. Yani ürün detay gibi

        // void Add(Product product); //Burada sadece ekleme, geriye bişey döndürmüyor.
        //Yukarıdaki eski hali alttaki yeni hali
        IResult Add(Product product); //Utlities den türeyen
        IResult Update(Product product);

    }
}
