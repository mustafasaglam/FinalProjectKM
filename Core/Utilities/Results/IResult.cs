using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için bailangıç. Void ler için işlem sonucu ve bilgilendirme mesajı olacak
    public interface IResult
    {
        // success başarılı mı başarısız mı?
        bool Success { get; } // Bu bir property. Get yani sadece okumak için, Set de olsa yazmak için olacaktı
        //Message de kullanıcıya verilecek mesaj
        string Message { get; }
    }
}
