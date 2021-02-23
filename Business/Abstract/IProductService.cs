using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //public yapalım. Bunlarda iş katmanında kullanacağımız iş katmanları
    // Bussiness Katmanımıza DataAccess ve Entities projelermizi project refrens olarak ekleriz.*** Çünkü busines hem entities hemde dataAccess katmanlarını kullanır.
    public interface IProductService
    {
        List<Product> GetAll();
    }
}
