using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //list döndüren metodlar için
    //Yani hem message ve success içerecek ama hemde bir data içerecek. Message ve succces için zaten bir yapı kurmuştuk kendimizi telrar etmemek için IResult implementasyonu yapıyoruz.
    public interface IDataResult<T>:IResult //Hangi tipi döndüreceğini bana söyle diyoruz/Yani ne döndüreceğini generic T ile belirtiyoruz
    {
        //IResult dan gelen message ve success haricinde tutacağımız datamız yani ürünlerimiz veya başka şeyler*
        T Data { get; }
    }
}
