using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Her zaman Bir Interface ile başladığımız gibi buradada aynı şekild ebaşladık ve class ımızı çıplak bırakmadık. Bu bir IResult implementasyonudur dedik.
    public class Result : IResult
    {
        public Result( bool success,string message):this(success) //this demek kendisi demektir. Yani this dedik Result u kastediyor. :this(succes) demek hem ilk consructr hemde ikinci success paarmetre alan consructr çaışsın demek
        {
            Message = message;
            
        }
        public Result(bool success)
        {
            Success = success;
        }

        //Sadece get olduğu için sadece => bundan sonrası {get;} yapıyoruz
        public bool Success { get; }

        public string Message { get; }
        
    }
}
