using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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
    }
}
