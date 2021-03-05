using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    //HTTP portundan istekleri işler
    //API ler Json formatta veri çıktısı verir
    //URL yapısı route niteliği ile api/products olarak gelir

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //naming convation / isimlendirme standardı _ppp

        //IoC Container : Inversion of Control / Değişimin kontrolü / Yani:Bellekte nesneleri newleyip tuttuğumuz yer.  İhtiyacı olana sunduğumuz : Bu işlemi de startUp.cs içerisinden den ayağa kaldırıyoruz. Web apinin kendi içindekki IoC yapısını kullanacaız

        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")] //Bu şekilde apiyi çağıracağımız zaman isim ile alias vermiş oluyoruz
        public IActionResult GetAll()
        {
            //Öncelikle api mize bir test verisi gönderidk hem tarayıcıda hem postmanda istek yaparak gördük
            //return new List<Product>
            //{
            //    new Product{ProductId=1,ProductName="Elma"},
            //    new Product{ProductId=2,ProductName="Armut"}
            //};

            //Şimdi Busines üzerinden veritabanımızdan çekelim
            //Bu ProductManager da olsa çalışır, Ama IProductService de manager ın referansını tutabiliyor
            //Burada bir bağımlılık var yani dependency chains / bağımlılık zinciri
            //Bu bağımlılı ortadan kaldırmak için contructr injection ile ortan kaldırtalım

            //IProductService productService = new ProductManager(new EFProductDal()); //contructur ile bağımlışlığı sonlandırıyoruz

            //List<Product> //Bir önceki hali için
            //var result=_productService.GetAll();
            //return result.Data;

            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result); //http 200 ok ile sonlanır
            }
            return BadRequest(result); //result.Message geçersek tüm veriyi json olarak döner //http 400 bad request ile döner

        }

        //Tek bir kayıtiçin get / ?nasıl çağıracağız?:
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Şimdi bir post operasyonu yazıp data ekleyelim
        [HttpPost("add")]  //buradaki httppost özniteliği olmalı
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        //Güncelleme için de [httpost] kullanılabilir.
        //Ancak güncelleme için [httpput]
        // Silme için [httpdelete] kullanılabilir

       
    }
}
