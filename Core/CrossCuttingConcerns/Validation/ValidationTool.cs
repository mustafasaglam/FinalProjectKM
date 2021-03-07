using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
   // public static olur. Static clasın metodlarıda static olmak zorundadır. c# dili için

    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object entity) // Değişen şeyleri parametre olarak vermeliyiz/ IValidator u çözeriz yükleriz // Biz buraya nesne entity veya dto ekleyebiliriz o yüzden hepsini kapsayan object türünde entity parametresi veririz
        {
            var context = new ValidationContext<object>(entity);  //using e ekle ValidationContext için //Product için doğrulama yapacağız diyoruz
            var result = validator.Validate(context); // sonra productValidator u Validate et
            if (!result.IsValid)  //Eğer resutl validate olmaz ise hatayı fırlat
            {
                throw new ValidationException(result.Errors);
            }
        

            //Son haline ve evrensel halibe refactor etmiş olduk
    }
}
}
