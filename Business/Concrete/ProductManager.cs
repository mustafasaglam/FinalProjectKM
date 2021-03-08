using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    //public yapalım
    public class ProductManager : IProductService  //Using e ekleyelim ve implement edelim**
    {
        IProductDal _productDal;  //Burada DataAcces projesindeki ProductDal global oalrak tanımlanır. VE üzerine gelip veya ampulden Generate Consructur denilerek yapıcı metodu oluşturulur.

        //ICategoryDal _categoryDal; //bir entityManager kendisi hariç başka bir Dal ı enjekte edemez *** Nedeni: Ek iş kurallar geldiğinde sorun oluşacağı için bu yanlış yöntemdir.Ancak bunun yerine Service enjekte ederiz***
        ICategoryService _categoryService;

        //Buna contructor injection denir
        public ProductManager(IProductDal productDal,ICategoryService categoryService)  //Generate Constructor ile otomatik oluşur.
        {
            _productDal = productDal;
            //_categoryDal = categoryDal; //bir entityManager kendisi hariç başka bir Dal ı enjekte edemez *** Nedeni: Ek iş kurallar geldiğinde sorun oluşacağı için bu yanlış yöntemdir. Bunun yerine Service enjekte edilir
            _categoryService = categoryService;

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
            //Demo bir iş kuralı yapalım
            //*******
            //Bir kategoride 10'dan fazla ürün var ise eklenmesin iş kuralını yazalım. aşağıdaki şekilde yazabilirz.*** Ancak bu kuralı evrensel yapmaz isek bunu güncellemede veya başka bir metodda kullanmak istersek her defasında kendimizi tekrar etmek durumunda kalırız. DRY prensibi. Veya iş kuralı değişirse onu kullandığımız her metodda değiştirmemiz gerekecek. Dolayısıyla sürdürülebilir değil
            //İş kurallarını bu şekilde yazar isek spagetti kod yazmış oluruz. 10 larca satır iş kuralı oldumu işler karmaşıklaşır. İlerleyen zamanlarda işler iyice karmaşıklaşır. TemizKod Clean kod yazmak için bujnu evrensel hale getirmek gerekir.

            /**var result = _productDal.GetAll(c => c.CategoryId == product.CategoryId).Count();
            if (result>=10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }*/

            //İş kuralımızı bir metod olarak tnaımlayıp aşağıdaki şekilde çağırıp kontrol ettiriyoruz

            //Şimdi bir iş kuralı daha yazalım. Aynı isimde ürün eklenemez*** Örnek

           //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success) && deyip peşine 2.kuralıda yazabilirdik ama iş kurallarında bu şkilde nested iç içe if kullanmak daha doğrudr.
           // {
           //     if (CheckIFProductNameExists(product.ProductName).Success)
           //     {
           //         _productDal.Add(product);
           //         return new SuccessResult(Messages.ProductAdded);
           //     }
           // }
           // return new ErrorResult();
           //Artık bu üsteki gibi iş kuralı vermemize gerek kalmadı. Çünkü Core içineki Utilities içinde BusinessRuless ile birlikte bir iş motoru yazdık. Ve iş kuralalrımızı dinamik olarak çekebileceğimiz bir yapı oluşturdulk
           
            //Yeni bir iş kuralı * Eğer mevcut kategori sayısı 15 i geçtiyse sisteme yeni ürün eklenemez**



            IResult result=BusinessRules.Run(CheckIFProductNameExists(product.ProductName),CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckCategoryCountLimit());
            if (result!=null)
            {
                return result; //kurallara uymaz ise result u döndürüyoruz uyuyor ise sorun yok ve devam eder
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

           
            
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            //Bu kısmıda add metoduna göre yapılandırmak gerekir
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                _productDal.Update(product);
                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();
            
        }

        public IDataResult<List<Product>> GetAll()
        {
            //Burada iş kodları var ise buraya yazılır
            //Yekisi varmı?
            //İf kontrolleri
            //Diyelim ki şartları sağladı o zaman ürünleri listeliyor...

            if (DateTime.Now.Hour == 00) // Saatleri 00 yaptım sonraki zamanalrda bize etki etmesin diye
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed); // Utilities entegrasyonlu son hali
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


        //İş kuralımız. Kategorideki ürünsayısını doğrula metodumuz. Private veriyoruz çünkü sadece bu classda kullanacağız. İş kuralları pubklic oalrak tanımlanmamalıdır.
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId) //Product product da geçilip ordan categoryid ye erişilir
        {
            var result = _productDal.GetAll(c => c.CategoryId == categoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }


        //aynı isimde ürün eklenemez

        private IResult CheckIFProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); //Any varmı demek !!*** any bool döndürür var ise tru dur. Any kullanmak yerine direk sorguyu çekip count a da bakabiliriz 0 dan farklıysa demkki vardır diyebilirz
            if (result==true) //ile if(result)  aynı şeydir !result true değilse demktir
            {
                return new ErrorResult(Messages.CheckIFProductNameExists);
            }
            return new SuccessResult();
        }

        //Eğer category sayısı 15 i geçerse yeni ürün eklenemez kuralı
        private IResult CheckCategoryCountLimit()
        {
            var result = _categoryService.GetAll().Data.Count(); //CategoryService yazdık cünkü ona ulaştık yukarıda.
            if (result>15)
            {
                return new ErrorResult(Messages.CheckCategoryCountLimit);
            }
            return new SuccessResult();
        }


        
    }
}
