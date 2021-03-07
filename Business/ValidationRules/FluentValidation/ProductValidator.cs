using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //Önce Nugetten FluentValidation paketi kurulur. Sonra Bussines içinde ValidationRules klasörü altında FluentValidation altındaki ProductValidator clası eklenerek productlar için doğrulama kontrolleir yazılır.

    //**** Fluent validasyon 19 farklı dilde destek veriyor. yani tarayıcı diline göre verecektir. ama özelleştirilebirlir. WithMessage
    public class ProductValidator : AbstractValidator<Product> //Bu abstractValidatorden miras laır ve Product için bir validasyon içindir. DTO lar içinde validasyon yazılır. Tabi genereic içinde dto geçilir.
    {
        //Bu doğrulama kuralları bir consructr içine yazılır. ctor deyip tab tab ile cnstr oluşturulur
        public ProductValidator()
        {
            //istersek bu kuralları tek satırdadayazabilir. Ama kuralları ayrı yazmak daha mantıklıdır. Çünkü kurallar değişebilir.
            //Mesela pasaport no zorunludur ama ne zaman yabancı uyruklu olduğu zaman gibi. Bu bir SOLID prensibidir.

            RuleFor(p => p.ProductName).NotEmpty(); //product name boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2); // p nin productname i minimum 2 karekter olabilir 
            RuleFor(p => p.UnitPrice).NotEmpty(); //fiyatı boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0); //unite price 0 dan farklı olmalıdır //u özelliklere bakılır. . deyip bakabilirz

            //Örneğin içecek kategorisinde ise ürün fiyatı minimum 10 olmalı da diyebilirz
            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

            //Olmayan bir kural eklemek istiyoruz
            //Ürünlerin isimleri A ile başlamalı diyebilirz veya bir desene uymalı
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A ile başlamalıdır."); // Must uymalı-gerekli StartWithA yazacağımız metod // ampulden generete metod diyip alta oluştururz

            /**** Fluent validasyon 19 farklı dilde destek veriyor. yani tarayıcı diline göre verecektir. ama özelleştirilebirlir. WithMessage
             * Özel yazdığımız metod olduğu için bunda mesajı biz özel yazdık
             */

          

        }

        private bool StartWithA(string arg) //boll dönecek demek. True dönerse uyar false uymaz demek / arg parametresi productname i temsil eder
        {
            return arg.StartsWith("A"); //A ile başlar ise true dön demek
        }
    }
}
