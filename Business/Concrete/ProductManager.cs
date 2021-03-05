using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            //Buiness kodlar, yani kurallar var ise, veya çeşitli ksııtlamalar
            if (product.ProductName.Length<2)
            {
                //Magic string tir bu şekild ekullanmak. Bunu azaltmak için Business e gidip Constants (Sabit demektir.)Hata mesajları yapılarılanı burada sabitleyeceğiz
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Burada iş kodları var ise buraya yazılır
            //Yekisi varmı?
            //İf kontrolleri
            //Diyelim ki şartları sağladı o zaman ürünleri listeliyor...

            if (DateTime.Now.Hour==00) // Saatleri 00 yaptım sonraki zamanalrda bize etki etmesin diye
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed); // Utilities entegrasyonlu son hali
        }


        // bumetodu IProductServisten sonradan entegre ediyoruz. Yine imlement dersek oraya bir metod eklediysek buraya eklenir.
        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));

        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 00) // Saatleri 00 yaptım sonraki zamanalrda bize etki etmesin diye
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
