using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //public yapalım
    public class ProductManager : IProductService  //Using e ekleyelim ve implement edelim**
    {
        IProductDal _productDal;  //Burada DataAcces projesindeki ProductDal global oalrak tanımlanır. VE üzerine gelip veya ampulden Generate Consructur denilerek yapıcı metodu oluşturulur.

        //Buna contructor injection denir
        public ProductManager(IProductDal productDal)  //Generate Constructor ile otomatik oluşur.
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //Burada iş kodları var ise buraya yazılır
            //Yekisi varmı?
            //İf kontrolleri
            //Diyelim ki şartları sağladı o zaman ürünleri listeliyor...

            return _productDal.GetAll();
        }


        // bumetodu IProductServisten sonradan entegre ediyoruz. Yine imlement dersek oraya bir metod eklediysek buraya eklenir.
        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);

        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
