using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Bu bizim her Nesnemizin Generic Repository TasatımDesenini tutacak Temel Interface i
    //Ve biz bu T generic tipini biz sınırlandırmamız lazım. Yani biz buna sadece veritabanı nesnelerini kullanacağımızı belirtiyoruz. Peki bizim veritabanı listelerimiz nedir class. Şimdi ona göre where T:class tır diyelim.
    //Yani buna Generic Constraint dir. Yani Generic kısıtlayıcı
    public interface IEntityRepository<T> where T:class,IEntity, new()//Çalışacağmız tipi T ile dinamic yapıyoruz //Yani buraya artık T bir class referans tipi olabilir diyoruz. ,IEntity olarak da belirtiyoruz. Yani ne diyoruz buraya herhnagi bir class ı değil bizim sadece IEntity olarak belirttiğimiz veritabanı classlarımızı geçebilir diyoruz*** Yani biz IEntity de geçebilir diyoruz nesnelerimize. Ama , new() ile buraya geçilecek clasın newlenebilir olması gerektiğini belirterek, IEntity nin verilmesini de kısıtlıyoruz. Çünkü IeEntity bir Interface dir ve interface ler newlenemez**** Ama bizim db nesnelerimiz ondan türediği için kısıtlamada onu belirtmemiz gerekir.
        
        //Çok önemli burası yukarıdaki açıklama***

    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);  // Tüm ürünleri çeken metodumuz. Ama artık generic mimaride T tipinde bir entity olarak veiryoruz *** / Burada kodlarımızı yine geliştirmeye devam ediyoruz ve bir Expression ekliyoruz. Bu expression bize sorgularımızda filtre koşulu eklememize sağlayacak.** Yani bu yapı ile Kategoriye göre getir veya fiyata göre getir gibi ayrı ayrı metodlar yazmamıza gerek kalmaaycak*** Filter=null filtre vermeye gerek yok ama istersen verebilirsinde demek.

        T Get(Expression<Func<T,bool>>filter); //Bu metodda filtre zorunlu diyoruz.eğer filtre vermemişse tüm datayı istiyor da diyebilirz

        void Add(T entity); //Product ekleme metodumuz, parametre olarak Product alıyor

        void Update(T entity); // Güncelleme işlemi için

        void Delete(T entity); // Silme işlemi için

        //Yeni bir metod ekleyelim
        //List<T> GetAllByCategory(int categoryId); // Buna artık ihtiyaç kalmıyor çünkü yukarıda expressin ile belirttik.***


        //Generic Repository nesnelerinde genelde bu 5 metod ve Id ye göre getirme olan metod barındırılır.
    }
}
