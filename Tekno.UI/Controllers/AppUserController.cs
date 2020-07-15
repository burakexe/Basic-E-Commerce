using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tekno.MODEL;
using Tekno.MODEL.Entity;
using Tekno.SERVICE.Option;
using Tekno.UTILITY;

namespace Tekno.UI.Controllers
{
    public class AppUserController : Controller
    {
        // GET: AppUser

        private AppUserService appUserService = new AppUserService();

        public ActionResult Complete(Guid id)
        {
            if (appUserService.Any(x => x.ActivationCode == id))
            {
                AppUser user = appUserService.GetByDefault(x => x.ActivationCode == id);
                user.IsActive = true;
                user.ActivationCode = Guid.NewGuid();
                appUserService.Update(user);
                ViewBag.ActivationStatus = 1;
            }
            else
            {
                ViewBag.ActivationStatus = 0;
            }
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        //todo:Login viewına ulaşmak için navbara link eklenmeli ex.Login

        public ActionResult KullanıcıUpdate(Guid? id)
        {
            using (TeknoDB db = new TeknoDB())
            {
                AppUser appuser = db.AppUsers.Find(id);
                return View(appuser);
            }
        }

        [HttpPost]
        public ActionResult KullanıcıUpdate(AppUser appUser)
        {
            using (TeknoDB db = new TeknoDB())
            {
                AppUser newappuser = db.AppUsers.Find(appUser.ID);
                newappuser.Name = appUser.Name;
                newappuser.Password = appUser.Password;
                newappuser.FirstName = appUser.FirstName;
                newappuser.LastName = appUser.LastName;
                newappuser.Email = appUser.Email;
                newappuser.PhoneNumber = appUser.PhoneNumber;
                newappuser.BirthDate = appUser.BirthDate;
                db.SaveChanges();
                return View();
            }
        }

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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser appUser, HttpPostedFileBase ImagePath)
        {
            //validation (doğrulama) kuralları yerine getirilmişse aşağıdaki karar yapısı içerisine girecektir.
            if (ModelState.IsValid) // Doğrulama Kuralı
            {
                if (appUserService.CheckUserName(appUser.Name))
                {
                    ViewBag.Exists = "Üye adı daha önce alınmış";
                    return View();
                }
                else if (appUserService.CheckEmail(appUser.Email))
                {
                    ViewBag.Exists = "Email adresi zaten kayıtlı!";
                    return View();
                }
                else
                {
                    appUser.ID = Guid.NewGuid();
                    appUser.Role = Role.member;
                    appUser.ActivationCode = Guid.NewGuid();
                    appUser.ImagePath = ImageUploader.UploadImage("~/Content/images", ImagePath);
                    appUserService.Add(appUser);
                    string message = $"Hoşgeldin {appUser.Name},\nKayıt işlemini tamamlamak için lütfen aşağıdaki bağlantıya tıklayın.\n{Request.Url.Scheme}{System.Uri.SchemeDelimiter}{Request.Url.Authority}/AppUser/Complete/{appUser.ActivationCode}";

                    MailSender.SendEmail(appUser.Email, "Kayıt talebiniz alındı!", message);
                    return RedirectToAction("Success", appUser);
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult Success(AppUser appUser)
        {
            if (appUser == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(appUser);
            }
        }
    }
}