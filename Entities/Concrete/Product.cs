using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Bir clasın default erişim belirteci Internal dır. Internal demek sadece bu projede erişebilir demektir. Biz diğer projelerde erişebildin diye bu clası public olarak işaretliyoruz.
    public class Product:IEntity //Ientity ekler ve using e ekleriz** // Bu şekilde IEntity ile işaretlememizin mantığı nedir? artık Ientity Product ın referansını tutabilmektedir***
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; } //Short int veritipinin bir küçüğü, northwindde smallint tutulduğu için burada böyle veridk
        public decimal UnitPrice { get; set; }
    }
}
