using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    //Category ile iligli dış dünyaya neyi servis etmek sitiyorsam
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll(); // hepsini getir
        IDataResult<List<Category>> GetById(int categoryId);//id ye göre 1 tane getir
    }
}
