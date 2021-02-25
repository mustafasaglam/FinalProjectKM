﻿using Business.Concrete;
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

            // ProductManagerTestMethod();
            // CategoryTest();
            ProductManager productManager = new ProductManager(new EFProductDal());
            foreach (var item in productManager.GetProductDetails())
            {
                Console.WriteLine(item.CategoryName +" "+ item.ProductName +" "+item.UnitsInStock);
            }


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

            foreach (var item in productManager.GetByUnitPrice(50, 100)) //Bize bellekteki listeden gelen isimleri ekrana yaz. Zamanla değişti..**
            {
                Console.WriteLine(item.ProductName);
            }
        }
    }
}
