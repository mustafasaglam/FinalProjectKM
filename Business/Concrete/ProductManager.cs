using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        [ValidationAspect(typeof(ProductValidator))] //artık validdation işleini bu attirubute yapacaktır
        public IResult Add(Product product)
        {
            //Buiness kodlar, yani kurallar var ise, veya çeşitli ksııtlamalar
            //Validation işlemleri, Doğrulamakodu? iş kodu? ayrımı nedir : İş kodunu ayrı, doğrulama kodunu ayrı yazmak gerekli !!

            //Doğrulama eklenmek istenen nesnenin YAPISAL olarak kontrol etmektir.*** Örneğin;Sistme kayıt olurken minumum şu karakter olmalı, veya şifre şöyle olmalı gibi kurallar doğrulama - validasyon yapısıdır.

            //İş kuralları şartlar sağlanıyormu diye kontrol eidldiğği yerdir. mesela sınavdan geçer not almış mı? Finansal puanı yeterlimi gibi kontroller iş kodudur.

            /** //Bu kısmı artık fluent validasyon ile yazdık o yüzden kapattık.FLUENT i aktif etmek için
            if (product.UnitPrice <= 0)
             {
                 return new ErrorResult("Fiyat 0dan küçük olamaz"); // Burda Messages dan da çağırabilirs bu ekildede verebilirz ama messages dan vermemiz doğru olanıdır
             }

             if (product.ProductName.Length < 2)
             {
                 //Magic string tir bu şekild ekullanmak. Bunu azaltmak için Business e gidip Constants (Sabit demektir.)Hata mesajları yapılarılanı burada sabitleyeceğiz
                 return new ErrorResult(Messages.ProductNameInvalid);
             }
             */


            //Fluent Validasyon kodlar
            //Burada validasyonu aktif etme kısmı basit bir kodlama oldu. Bunu tüm projelerde kullanmak ve dinamik hale getirmek için Core içinde bir CrossCuttingConcerns klasörü oluşturulup buradan yönetilebilir. Yani bu aşağıdaki kodu Bir Tool haline getireyim. /* */ içindeki kodları buradan alıp Core içinde CrossCuttingConcerns içinde Validation içindeki ValidationTool clasına ekleyelim.

            /* var context = new ValidationContext<Product>(product);  //using e ekle ValidationContext için //Product için doğrulama yapacağız diyoruz
            ProductValidator productValidator = new ProductValidator(); //ProductValidator u kullnarak kuralları isteyeceğim
            var result = productValidator.Validate(context); // sonra productValidator u Validate et
            if (!result.IsValid)  //Eğer resutl validate olmaz ise hatayı fırlat
            {
                throw new ValidationException(result.Errors);
            }*/

            //ValidationTool.Validate(new ProductValidator(), product); //artık yukarıdaki işlemi Coreda evrensel hale getirdiğimiz için burada bu kod validasyon için bize yetecektir.
            //*Artık attirubute ile vererek burada validaston satırınıda kaldırabilirz

            //Business Kodlar

            
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
