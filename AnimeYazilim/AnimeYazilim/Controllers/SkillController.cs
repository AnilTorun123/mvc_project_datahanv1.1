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
    [Authorize]
    public class SkillController : Controller
    {
        // GET: Skill

        SkillManager sm = new SkillManager(new EfSkillDal());
        public ActionResult Index()
        {
            var values = sm.GetList();

            return View(values);
        }

        [HttpGet]
        public ActionResult Index2()
        {
            var values = sm.GetList();

            return View(values);
        }

        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(Skill p)
        {
            p.Name = "Anıl Torun";
            p.About = "Github: AnilTorun123";
            sm.SkillAdd(p);
            return RedirectToAction("Index");
        }

        public PartialViewResult AddSkillPartial()
        {
            return PartialView();
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = sm.GetByID(id);
            sm.SkillDelete(value);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var value = sm.GetByID(id);
            return View(value);

        }
        [HttpPost]
        public ActionResult EditSkill(Skill p)
        {
            sm.SkillUpdate(p);
            return RedirectToAction("Index");

        }
    }
}