using System;
using System.Linq;
using System.Web.Mvc;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private OrderService orderService = new OrderService();

        public ActionResult Index()
        {
            //todo: üyeler listelenecek.
            var users = orderService.GetAll().ToList();
            return View(users);
        }

        public PartialViewResult Add()
        {
            Order temp = new Order();

            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult Add(Order order)
        {
            Order temp = order;
            orderService.Add(order);

            return RedirectToAction("Index");
        }

        public PartialViewResult Detail(Guid id)
        {
            Order temp = orderService.GetById(id);

            return PartialView(temp);
        }

        public PartialViewResult Edit(Guid id)
        {
            Order temp = orderService.GetById(id);
            return PartialView(temp);
        }

        [HttpPost]
        public ActionResult Edit(Order order)
        {
            Order temp = orderService.GetById(order.ID);
            temp.Name = order.Name;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            Order temp = orderService.GetById(id);
            orderService.Remove(temp);

            return RedirectToAction("Index");
        }
    }
}