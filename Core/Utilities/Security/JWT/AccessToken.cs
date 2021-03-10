using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //Erişim Anahtarı
    public class AccessToken
    {
        public string Token { get; set; } //Kullanıcı girerken oluşturacağımız token bilgisi
        public DateTime Expiration { get; set; } //ve bu tokenin btişi süresi
    }
}
