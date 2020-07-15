using System;
using System.Linq;
using System.Web.Mvc;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Areas.Admin.Controllers
{
    public class OrderDetailController : Controller
    {
        private OrderDetailService OrderDetailService = new OrderDetailService();
        // GET: Admin/AppUser

        public ActionResult Index()
        {
            //todo: üyeler listelenecek.
            var users = OrderDetailService.GetAll().ToList();
            return View(users);
        }

        public PartialViewResult Add()
        {
            OrderDetail temp = new OrderDetail();

            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult Add(OrderDetail orderDetail)
        {
            OrderDetailService.Add(orderDetail);
            return RedirectToAction("Index");
        }

        public PartialViewResult Detail(Guid id)
        {
            OrderDetail temp = OrderDetailService.GetById(id);

            return PartialView(temp);
        }

        public PartialViewResult Edit(Guid id)
        {
            OrderDetail temp = OrderDetailService.GetById(id);
            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult Edit(OrderDetail orderDetail)
        {
            OrderDetail temp = OrderDetailService.GetById(orderDetail.ID);
            temp.Name = orderDetail.Name;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            OrderDetail temp = OrderDetailService.GetById(id);
            OrderDetailService.Remove(temp);

            return RedirectToAction("Index");
        }
    }
}
