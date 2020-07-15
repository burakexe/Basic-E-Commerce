using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tekno.MODEL;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        CategoryService cs;
        public CategoryController()
        {
            cs = new CategoryService();
        }

        public ActionResult Index()
        {
            return View(cs.GetActive());
        }



        public PartialViewResult Add()
        {
            Category temp = new Category();

            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {

            cs.Add(category);
            return RedirectToAction("Index");
        }


        //Güncelle
        public ActionResult Update(Guid id)
        {
            var result = cs.GetById(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult Update(Category category)
        {
            cs.Update(category);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(Guid id)
        {


            Category temp = cs.GetById(id);
            cs.Remove(temp);

            return RedirectToAction("Index");

        }
    }

}
