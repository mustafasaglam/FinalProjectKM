using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //**ProductManager productManager = new ProductManager(new InMemoryProductDal());  //InMemoryProductDal IProductDal ın referansını tutabildiği için onu parametre olarak veriyoruz. Şuan bu şu demek ben InMemory teknoloji ile çalışacağım.

            //Şimdi yukarıdaki ProductManager ile InMemoryProductDal ile çalışacağımızı söylüyoruz. Ve Alttakinde de EFProductDal ile çalışacağımzıı söylüyoruz yani Teknoloji altyapı değişimi yapmış oluyor.

            ProductManager productManager = new ProductManager(new EFProductDal()); //Bu şekildede Artık Entity Framework altyapısını kullnacağımızı belirriyoruz!!!***

            foreach (var item in productManager.GetByUnitPrice(50,100)) //Bize bellekteki listeden gelen isimleri ekrana yaz. Zamanla değişti..**
            {
                Console.WriteLine(item.ProductName);
            }
            
        }
    }
}
