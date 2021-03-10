using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages // public ve static veriyoruz. static demek newlenmez demektir. Messages deriz direk kullanılır
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductListed = "Ürünler Listelendi";
        public static string MaintenanceTime = "Bakım zamanı / Ürünler getirilmedi :)";

        public static string ProductCountOfCategoryError = "Eklemek istediğiniz kategoride 10 dan fazla ürün vardır. İş kuralı gereği eklenemez";

        public static string CheckIFProductNameExists = "Aynı isimde bir ürün bulunmaktadır. Eklenemez!!";

        public static string CheckCategoryCountLimit="Sistemdeki kategori sayısı 15 den fazla olamayacağı için ürün eklenemez";
        public static string AuthorizationDenied = "Yetkiniz yoktur";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
