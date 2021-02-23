using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new InMemoryProductDal());  //InMemoryProductDal IProductDal ın referansını tutabildiği için onu parametre olarak veriyoruz. Şuan bu şu demek ben InMemory teknoloji ile çalışacağım.

            foreach (var item in productManager.GetAll()) //Bize bellekteki listeden gelen isimleri ekrana yaz. 
            {
                Console.WriteLine(item.ProductName);
            }
            
        }
    }
}
