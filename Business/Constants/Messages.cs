using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages // public ve static veriyoruz. static demek newlenmez demektir. Messages deriz direk kullanılır
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Bakım zamanı / Ürünler getirilmedi :)";
    }
}
