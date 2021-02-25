using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Category ile iligli dış dünyaya neyi servis etmek sitiyorsam
    public interface ICategoryService
    {
        List<Category> GetAll(); // hepsini getir
        List<Category> GetById(int categoryId);//id ye göre 1 tane getir
    }
}
