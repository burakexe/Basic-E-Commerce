using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        CategoryService cs;
        public CategoryController()
        {
            cs = new CategoryService();
        }

        public ActionResult Index()
        {

            return View(cs.GetActive());
        }

        public ActionResult Remove(Guid id)
        {
            cs.Remove(id);
            return RedirectToAction("Index");
        }
    }
}