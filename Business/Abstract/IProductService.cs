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
        List<Product> GetAll(); // Tüm kategorileri getir.

        List<Product> GetAllByCategoryId(int id); //Kategori id ye göre ürünleri getir**

        List<Product> GetByUnitPrice(decimal min, decimal max); //Örneğin şu fiyat aralığında olan ürünleri getir diyeceğiz

        List<ProductDetailDto> GetProductDetails();

    }
}
