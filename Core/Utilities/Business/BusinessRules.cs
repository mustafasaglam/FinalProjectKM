using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //IResult türünde bir params dizisi parametresi veriyoruz. Yani iş kurallarını çağırırken birden fazla kuralı vermek için..
        {
            foreach (var logic in logics)
            {
                if (!logic.Success) //Başarılı değilse
                {
                    return logic;
                }
            }
            return null; // Başarılı ise null döndürmesini istedik.
        }
    }
}
