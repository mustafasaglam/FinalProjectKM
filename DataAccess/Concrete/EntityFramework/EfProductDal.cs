using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFProductDal : EfEntityRepositoryBase<Product,NorthwindContext>, IProductDal //Son hali** :) //
    {
        //Artık burada son hali ve burası artık Product a ait özel durumlar için kullanacağız**





        //öğrenirken liste doldurmak için yapmıştık ilerleyince yorum satırı yaptım**
        ////List<Product> _products;

        ////public EFProductDal()
        ////{
        ////    _products = new List<Product>
        ////    {
        ////        new Product{ProductName="Kulaklık"},
        ////        new Product{ProductName="Hoparlör"}
        ////    };
        ////}

        ////public List<Product> GetAll() kendimiz test için elle yazmıştık***
        ////{
        ////    return _products;
        ////}
        

        

        
    }
}
