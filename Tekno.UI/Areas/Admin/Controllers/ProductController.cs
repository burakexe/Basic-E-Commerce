using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;
using Tekno.UTILITY;

namespace Tekno.UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService = new ProductService();
        private SubCategoryService subCategoryService = new SubCategoryService();

        public ActionResult Index()
        {
            var users = productService.GetAll().ToList();

            return View(users);
        }

        public ActionResult Add()
        {
            TempData["SubCategories"] = subCategoryService.GetActive();

            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                product.ImagePath = ImageUploader.UploadImage("~/Content/images", ImagePath);
                if (product.ImagePath == "0")
                {
                    ViewBag.Error = "Dosya Boş";
                }
                else if (product.ImagePath == "1")
                {
                    ViewBag.Error = "Zaten bu isimde dosya bulunmaktadır";
                }
                else if (product.ImagePath == "2")
                {
                    ViewBag.Error = "Dosya uzantısı belirtilenlere uymuyor";
                }
                else
                {
                    ViewBag.Produts = productService.GetAll();
                    productService.Add(product);
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        public PartialViewResult Detail(Guid id)
        {
            Product temp = productService.GetById(id);

            return PartialView(temp);
        }

        public ActionResult Update(Guid id)
        {
            Product pr = productService.GetById(id);

            return View(pr);
        }

        [HttpPost]
        public ActionResult Update(Product product, SubCategory subc)
        {
            Product pr = productService.GetById(product.ID);
            SubCategory sc = subCategoryService.GetById(subc.ID);
            pr.ID = product.ID;
            pr.Name = product.Name;
            pr.Price = product.Price;
            pr.UnitsInStock = product.UnitsInStock;
            sc.ID = subc.ID;
            subCategoryService.Update(sc);
            productService.Update(pr);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            Product temp = productService.GetById(id);
            productService.Remove(temp);

            return RedirectToAction("Index");
        }
    }
}