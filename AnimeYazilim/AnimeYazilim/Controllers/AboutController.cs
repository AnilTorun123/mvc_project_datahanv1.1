using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeYazilim.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        AboutManager am = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();
            return View(aboutvalues);
        }
        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            p.AboutStatus = true;
            am.AboutAdd(p);
            return RedirectToAction("Index");
        }
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
        public ActionResult SwapActiveOrPasive(int id)
        {
            var values = am.GetByID(id);
            if (values.AboutStatus == true)
            {
                values.AboutStatus = false;
                am.AboutUpdate(values);
            }
            else
            {
                values.AboutStatus = true;
                am.AboutUpdate(values);
            }
            return RedirectToAction("Index");
        }


    }
}