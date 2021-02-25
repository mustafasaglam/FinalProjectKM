using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    //DTO : Data Transfering Object //Yani tablolar arası join operasyonlarını yönettiğimiz kısım / Entities altında DTOs altında tutulurlar.
    public class ProductDetailDto:IDto //Bunuda IDto den miras aldırıyoruz. Çünkü bu direkt bir tablo değil IEntity diyemeyiz. Birkaç tablonun birleşimi olabilceği için onuda class çıplak kalmasın  diye IDto dan türetiyoruz. IDto ya tıklayp ışıktan Genereta new type deyip Vore katmanı altında Entities klasörü altına ekleriz. Yani Dto objelerimizin imzasıdır  bu.***
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
