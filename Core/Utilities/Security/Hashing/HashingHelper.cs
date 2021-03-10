using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //Bu biizm için bir yardımcı araç. Hash işlemleri için kullanacağız
    public class HashingHelper
    {
        //bize verdiğimiz şifresnin hash ini oluşturacak //out ile dışarıya byte array olrak out ile passwordHAsh ve salt değerlerini verecek.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //System.Security.Cryptography altındaki sha veya md5 gibi bir çok .net security kütüphanesinden yararlanarak password sal hash değerlerini oluşturacağız
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; // PaswordSalt bu şekilde
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //ComputeHash ile de hashlenmiş halini oluşturuyoruz. ancak bizden bunu bir byte array olarak istediği için Encoding.UTF8.GetBytes() metodu ile bu string değerin buyte halini dönüştürerek veriyoruz.
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) // doğrulama metodumuz. şifre has i doğrulamak için yani girişlerde, burada out olmaz çünkü biz girilen şifreyi vereceğiz. Yani kullanıcının girdiği şifreyi doğrulamak için
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //Girilen şifreyi hashlenmiş hali
                for (int i = 0; i < computedHash.Length; i++) //girilen şifrenin hashlenmiş array halinin tüm elemenlarını gez
                {
                    if (computedHash[i]!=passwordHash[i]) //hesaplanan hash pasword ün i. değeri db deki şifrelenin heshlenmiş halinin i. değerine eşit değilse false döndür
                    {
                        return false;
                    }
                }
                //eğer yukarıdaki bloğa girmez ise true döndür
                return true;
            }
           

        }
    }
}
