using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeYazilim.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager cm = new ContentManager(new EfContentDal());
        
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult GetAllContent(string p)
        {
            //if (p == null)
            //{
            //    var values = cm.GetList();
            //    return View(values.ToList());
            //}
            //else
            //{
            //    var values = cm.GetList(p);
            //    return View(values);
            //}

            var values = cm.GetList(p);
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}