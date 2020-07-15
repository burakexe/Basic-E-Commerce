using System;
using System.Web.Mvc;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        private SubCategoryService SubCategoryService = new SubCategoryService();
        private CategoryService cs = new CategoryService();

        public ActionResult Index()
        {
            ViewBag.Categories = cs.GetActive();
            return View(SubCategoryService.GetActive());
        }

        public ActionResult Add()
        {
            return View(cs.GetActive());
        }

        [HttpPost]
        public ActionResult Add(SubCategory subCategory)
        {
            subCategory.ID = Guid.NewGuid();
            SubCategoryService.Add(subCategory);
            return RedirectToAction("Index");
        }

        public PartialViewResult Detail(Guid id)
        {
            SubCategory temp = SubCategoryService.GetById(id);

            return PartialView(temp);
        }

        public ActionResult Edit(Guid id)
        {
            SubCategory temp = SubCategoryService.GetById(id);
            TempData["cs"] = cs.GetActive();
            return View(temp);
        }

        [HttpPost]
        public ActionResult Edit(SubCategory subCategory)
        {
            SubCategoryService.Update(subCategory);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            SubCategory temp = SubCategoryService.GetById(id);
            SubCategoryService.Remove(temp);

            return RedirectToAction("Index");
        }
    }
}