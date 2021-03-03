using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        public SuccessResult(string message) : base(true, message) //Base demek Result a gönder demek
        {

        }

        public SuccessResult() : base(true) //Base in tek parametre olannı çalıştır. Yani mesaj göndermeyeceğim demek
        {

        }
    }
}
