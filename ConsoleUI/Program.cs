using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //**ProductManager productManager = new ProductManager(new InMemoryProductDal());  //InMemoryProductDal IProductDal ın referansını tutabildiği için onu parametre olarak veriyoruz. Şuan bu şu demek ben InMemory teknoloji ile çalışacağım.

            //Şimdi yukarıdaki ProductManager ile InMemoryProductDal ile çalışacağımızı söylüyoruz. Ve Alttakinde de EFProductDal ile çalışacağımzıı söylüyoruz yani Teknoloji altyapı değişimi yapmış oluyor.

            // ProductManagerTestMethod();
            // CategoryTest();
            ProductManager productManager = new ProductManager(new EFProductDal());
            var result = productManager.GetProductDetails();

            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.CategoryName + " " + item.ProductName + " " + item.UnitsInStock);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            //**ProductManagerda yazdığımız saat 23 ise hata fırlatsın mesajı çalışır tabi saat 23 ise :)




        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProductManagerTestMethod()
        {
            ProductManager productManager = new ProductManager(new EFProductDal()); //Bu şekildede Artık Entity Framework altyapısını kullnacağımızı belirriyoruz!!!***

            foreach (var item in productManager.GetByUnitPrice(50, 100).Data) //Bize bellekteki listeden gelen isimleri ekrana yaz. Zamanla değişti..**
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
