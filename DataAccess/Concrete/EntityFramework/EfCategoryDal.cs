using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    //Sen bir IProductDal sın diyoruz ve implemente ederek metodları alıyoruz. Bundan sonr abiz buranın içini EntityFramework ile kodlayacağız.
    public class EfCategoryDal : EfEntityRepositoryBase<Category, NorthwindContext>, ICategoryDal
    {
        // artık burada Category için özel metodlar burada yazılacak** :)
    }
}
