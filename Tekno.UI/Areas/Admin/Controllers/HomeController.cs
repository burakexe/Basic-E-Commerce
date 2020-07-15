using System.Linq;
using System.Web.Mvc;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home

        public ActionResult AddProduct()
        {
            return View();
        }

        //[AuthenticationFilter]
        //[Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Index()
        {
            AppUserService appUserService = new AppUserService();
            var appUSer = appUserService.GetAll();
            var countUsers = appUSer.Count();
            Session["countUsers"] = countUsers.ToString();//kullanıcı sayısı

            ProductService productService = new ProductService();
            var product = productService.GetAll();
            var countProduct = product.Count();
            Session["countProduct"] = countProduct;// urun sayısı

            var sonKullanici = appUserService.GetAll().OrderByDescending(x => x.CreatedDate).Take(3);
            TempData["sonKullanıcı"] = sonKullanici;

            var sonUrun = productService.GetAll().OrderByDescending(x => x.CreatedDate).Take(3);
            TempData["sonUrun"] = sonUrun;

            OrderDetailService orderDetailService = new OrderDetailService();
            var totalPrice = orderDetailService.GetAll().Sum(x => x.Quantity * x.Price * 1 - (x.Discount));
            Session["totalPrice"] = totalPrice;

            var orderDetail = orderDetailService.GetAll();
            var countOrderDetail = orderDetail.Count();
            Session["countOrder"] = countOrderDetail;
            return View();
        }
    }
}