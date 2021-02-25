using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Artık clasımızı ekledikten sonra lışkanlık yaparak onun erişim tipini public veriyorum çünkü diğer katmanlarımında erişmesi gerekmektedir.

    //Çıplak Class Kalmasın ** Bir standarttır
    //Yani bir class herhangi bir inheratance veya bir interface implementasyonu almıyorsa ilerde sorun çıkaracaktır.
    //Bu varlıklarımızı gruplamamız gerekir
    //Bu gruplama; Cponcrete klasöründeki classlar bir veritabanı tablosuna karşılık gelmektedir.
    //Dolayısıyla Abstract klasörüne gelip IEntity olarak bir Interface ekleyerek
    public class Category: IEntity   // Buraya Ientity deyip using e ekleriz** Bu şekilde IEntity ile işaretlememizin mantığı nedir? artık Ientity Category ın referansını tutabilmektedir***
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
