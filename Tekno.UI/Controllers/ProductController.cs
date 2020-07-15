using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;
using Tekno.UI.Models.Basket;

namespace Tekno.UI.Controllers
{
    public class ProductController : Controller
    {


        OrderService orderService = new OrderService();
        AppUserService appUserService = new AppUserService();
        ProductService productService = new ProductService();//ilk olarak product serviceden instance aldık ki oda baseservis e gitsin ve databse ile bağlantı olsun yani burda project context yapmıyoruz çünkü baseservicede yapıldı ve metotlar tanımlandı.


        //List the Product from Product/Index
        public ActionResult Index()
        {
            return View(productService.GetAll());
        }


        //Sepete Ekle
        public ActionResult AddToCart(Guid id)
        {
            //addtocart diye id parametreli bir metot oluşturduk,ve başında bi karar yapısı kıllandık ,dedik ki session[sbasket] null ise basketin instance ını al yeniden oluştur,eğer null değilse sessiona cast işlemi yaparak onun basket tipinde davranması gerektiğini söyledik
            Basket b = Session["sbasket"] == null ? new Basket() : Session["sbasket"] as Basket;


            Product eklenecekUrun = productService.GetById(id);

            SelectedProduct sp = new SelectedProduct();
            sp.ID = eklenecekUrun.ID;
            sp.Name = eklenecekUrun.Name;
            sp.Price = Convert.ToDecimal(eklenecekUrun.Price);//decimala convert ettik çünkü selectedproducttaki price decimal tanımlanmış.ama product ilk tanımlandığında price decimal tanımlanmamış.

            b.AddProduct(sp);//basket tipinde b oluşturmuştuk bunun içine ürün attık.
            Session["sbasket"] = b;//bu toplam ürün basketinide sessiona attık.


            if (appUserService.Any(x => x.Role == (Role)1))//giren kişinin ziyaretçi olduğu durumda ne yapması gerektiğini söyledim
            {
                Session["ziyaretci"] = (Role)1;
                return View("Index", "Index");

            }
            return RedirectToAction("Index", "Home");
        }

        //Sepet
        public ActionResult MyCart()
        {
            if (Session["sbasket"] != null)
            {
                Basket cart = Session["sbasket"] as Basket;
                return View(cart.MyBasket);//toplam sepetteki ürünü göster

            }
            else
            {
                return RedirectToAction("MyCart");
            }

        }

        public ActionResult RemoveCart()
        {
            Session.Remove("sbasket");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult FinishShopping()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult FinishShopping(NewOrder newOrder)
        //{
        //    //Sepetteki ürünleri ve kullanıcıyı new order classı dolduruyoruz. Eğer her şey tamamsa ödemeye göndericez.
        //    //todo:newOrderdaki bilgiler database gönderilcek
        //    var order = newOrder;
        //    return View();
        //}

    }
}