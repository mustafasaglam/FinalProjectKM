using Core.DataAccess;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user); //BURADA BİR JOİN İŞLEMİ OLDUĞU İÇİN EKSTRADAN İŞLEM EKLEDİK/ sisteme girtiş çıkıştan ziyade claimleri çekmek istediğimiz için
    }
}
