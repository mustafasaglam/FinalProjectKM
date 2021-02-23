using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Yine public hale getiriyoruz
    //Ve yine InMemoryProductDal bir IProductDal dır diyoruz ve usinge ekliyoruz sonra metodları enjekte ediyoruz. İmplemente ediyoruz.
    
    public class InMemoryProductDal : IProductDal
    {
        //Biz bellekte çalışacağımız için bize bir ürün listesi lazım. Bu listeyi clasın dışında tanımlarız. Ve bu değişkenlere global değişken denir. tabiki o class için global değişkendir. _ ile isimlendirilir bu global değişkenler*** Şimdi biz bu listeyi bellekte referans aldığı zaman doldurmak için bir constructor bloğunda dolduralım. consructor yapıcı metoddur. Yani ilk çalıştığında burası çalışır**

        List<Product> _products;
        public InMemoryProductDal()
        {
            //Produucts listimizin içini aşağıdaki gibi fake ürünleri bellekte oluşturalım. yani bu bize sanki bir , oracle ,sql veya postgresql db den geliyormuş gibi düşünelim
            _products = new List<Product> {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitInStock=15,UnitPrice=15}, //her new product yeni ürün dekle demktir**
            new Product{ProductId=2,CategoryId=2,ProductName="Kamera",UnitInStock=3,UnitPrice=500},
            new Product{ProductId=3,CategoryId=2,ProductName="Telefon",UnitInStock=15,UnitPrice=1500},
            new Product{ProductId=4,CategoryId=2,ProductName="Klavye",UnitInStock=65,UnitPrice=150},
            new Product{ProductId=5,CategoryId=2,ProductName="Mouse",UnitInStock=1,UnitPrice=85}
            };
        }

        public void Add(Product product)
        {
            _products.Add(product); //Burada _products.Add dememizin sebbei yukarda oluşturduğumuz bellekteki sanal db ye eklemek için
        }

        public void Delete(Product product)
        {
            //Tek tek _products ı dolaşıp bakıyorum gelen product id döndüğüm listede olan kayıt var ise onu sil demiş oluyoruz
            //Bu kısmı Ef linq ile revize edeceğiz. LINQ (Language Integrated Query - Dile Gömülü Sorgulama - Yani bu kısmı linq ile çok kısa yazacağız)
            //Dolayısıyla aşağıdaki döngüye ve if e ihtiyaç olmayacak
            ////Product productToDelete=null;
            ////foreach (var p in _products)
            ////{
            ////    if (product.ProductId==p.ProductId)
            ////    {
            ////        productToDelete = p;
            ////    }
            ////}

            //Linq ile
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId); //Yukarıda yaptığımız işin kısası // System.Linq i using e ekledik //SingleORDefault 1 kayıt arar/Yerine First de olur FirstOrDefault da olur**
            //Lambda expression ile p öyleki => p.productid == product dan gelen productid ye eşit olanı sil dedik.
            _products.Remove(productToDelete); // Burada da gelen id ye göre seçtiğimiz kaydı sil diyoruz**

            //_products.Remove(); bu şekilde yazar isek bu şekilde listeden eleman silemeyiz. Çünkü burda nesnein referans ı değişiyor. Bellekteki referans ı değişiyor
        }

        public List<Product> GetAll()
        {
            return _products; //Tüm listeyi döndürüyoruz.
        }

        public List<Product> GetByGategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); //şart olarak linq de diyoruz ki productsda categoryId si bize listelenmek istenen categoryId ye eşit olanları getir diyoruz
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);  //Yine güncellenecek kaydı, gönderilen Id bilgisine göre git listeden bul demek.
            productToUpdate.ProductName = product.ProductName; //Ve id ile bulunan kaydın alanlarını bize parametre olarak gelen product bilgisinden gelen data olarak eşitliyoruz
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitInStock = product.UnitInStock;
            
        }
    }
}
