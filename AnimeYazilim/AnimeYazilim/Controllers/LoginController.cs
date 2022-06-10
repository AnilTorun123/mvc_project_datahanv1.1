using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft;
using System.Net;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Newtonsoft.Json;

namespace AnimeYazilim.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager wlm = new WriterLoginManager(new EfWriterDal());
        AdminManager am = new AdminManager(new EfAdminDal());
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult Index(Admin p)
        //{

        //    Context c = new Context();
        //    var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
        //    if (adminuserinfo != null)
        //    {
        //        FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
        //        Session["AdminUserName"] = adminuserinfo.AdminUserName;
        //        return RedirectToAction("Index", "AdminCategory");
        //    }
        //    else
        //    {

        //        return RedirectToAction("Index");
        //    }

        //}

        [HttpPost]
        public ActionResult Index(string username, string password, Admin p)
        {

            var degerList = am.GetList();
            var deger = degerList.Where(x => x.AdminUserName == username && x.AdminPassword == password).FirstOrDefault();


            if (deger != null)
            {
                FormsAuthentication.SetAuthCookie(deger.AdminUserName, false);
                Session["AdminUserName"] = deger.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }

            ViewBag.Hata = "Kullanıcı adı ya da şifre yanlış";
            return View();
        }


        [HttpGet]
        public ActionResult AnimeLoginIndex()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AnimeLoginIndex(Writer p)
        {

            Context c = new Context();
            var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("Index", "Anime");
            }
            else
            {
                return RedirectToAction("AnimeLoginIndex");
            }

        }
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writeruserinfo = wlm.GetWriter(p.WriterMail, p.WriterPassword);
            if (writeruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);
                Session["WriterMail"] = writeruserinfo.WriterMail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        //
        [HttpPost]
        public ActionResult FormSubmit()
        {
            Context c = new Context();
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LdV1SMgAAAAAA4MwZBJ5bhdPP2MrA4jFrIionp-";
            var client = new WebClient();

            ViewData["Message"] = "Google reCaptcha validation success";

            return View("Index");
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }

        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }

            [JsonProperty("error-codes")]
            public List<string> ErrorCodes { get; set; }
        }
    }
}

// Sitenin iki farklı bölümü için 2 farklı login giriş sistemi yapmak istedim tasarımsal olarak. Fakat 2 sinden birini kabul ediyor web config kısmında ki bu bölüm;

    //< authentication mode = "Forms" >
       //< forms loginUrl = "/Login/Index/" ></ forms >
      //</ authentication >    

//fakat çalışıyor webconfig deki kısmı değiştirmemiş olsamda. Neden?? sadece tahminimce üstteki controllerdakiler ile örtüştüğü için sorun yaratmıyor. ama tamamen bağımsız olsun diye yola cıkmıstım fakat bir sorunda yok yani. bilmiyorum bir seyler yanlıs gibi.. ama >HİÇ BİR SORUN YOK< Hatalarla boğuşmadan rahat edemiyormuyum ne..