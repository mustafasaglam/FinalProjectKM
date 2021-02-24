using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Public yaptık
    public interface ICustomerDal:IEntityRepository<Customer> //Buraya geldik ve IentityRepository sin v eCustomer ile çalıaşcaksın dedik.
    {

    }
}
