using AnimeYazilim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeYazilim.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }
        public List<CategoryClasss> BlogList()
        {
            List<CategoryClasss> ct = new List<CategoryClasss>();
            ct.Add(new CategoryClasss()
                {
                    CategoryName ="Yazılım",
                    CategoryCount = 8
                });
            ct.Add(new CategoryClasss()
            {
                CategoryName = "Anime",
                CategoryCount = 4
            });
            ct.Add(new CategoryClasss()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            ct.Add(new CategoryClasss()
            {
                CategoryName = "Projeler",
                CategoryCount = 1
            });
            return ct;
        }
    }
}