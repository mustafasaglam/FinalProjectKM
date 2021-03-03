using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Hata sonuçları, yani false durumları
    public class ErrorResult:Result
    {
        public ErrorResult(string message) : base(false, message) //Base demek Result a gönder demek
        {

        }

        public ErrorResult() : base(false) //Base in tek parametre olannı çalıştır. Yani mesaj göndermeyeceğim demek
        {

        }
    }
}
