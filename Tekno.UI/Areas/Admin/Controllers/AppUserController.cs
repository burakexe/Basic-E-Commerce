using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;

namespace Tekno.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        private AppUserService appUserService = new AppUserService();


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser model)
        {
            var user = appUserService.GetAll().Where(x => x.Name == model.Name && x.Password == model.Password).FirstOrDefault();
            if (user == null)
            {
                ViewBag.Error = "Böyle bir kullanıcı bulunamadı";
                return View("Register", "AppUser");
            }
            else
            {
                //Session
                Session["login"] = user;
                FormsAuthentication.SetAuthCookie(user.Name, true);
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View("Login");
        }


        public ActionResult Index()
        {
            return View(appUserService.GetActive());
        }


        public ActionResult Details(Guid id)
        {
            return View(appUserService.GetById(id));
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(AppUser appUser)
        {
            if (ModelState.IsValid)
            {
                if (appUserService.CheckUserName(appUser.UserName))
                {
                    ViewBag.Exists = "Üye adı daha önce alınmış";
                    return View();
                }
                else
                {
                    appUserService.Add(appUser);
                    TempData["Kayit"] = "Kaydınız alındı,giriş yapabilirsiniz";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            return View(appUserService.GetById(id));
        }


        [HttpPost]
        public ActionResult Edit(AppUser appUser)
        {
            try
            {
                appUserService.Update(appUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(appUserService.GetById(id));
        }


        [HttpPost]
        public ActionResult Delete(AppUser appUser)
        {
            try
            {
                appUserService.Remove(appUser);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}