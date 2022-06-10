using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace AnimeYazilim.Controllers
{
    public class AnimeController : Controller
    {
        AnimeManager am = new AnimeManager(new EfAnimeDal());
        AnimeEpisodeManager aem = new AnimeEpisodeManager(new EfAnimeEpisodeDal());
        Context c = new Context();
        // GET: Anime
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            //p = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            //var animevalues = am.GetListByWriter(writeridinfo);
            var animevalues = am.GetList().ToPagedList(page, 9);
            return View(animevalues);
        }
        public ActionResult IndexAdmin(int page = 1)
        {
            //p = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            //var animevalues = am.GetListByWriter(writeridinfo);
            var animevalues = am.GetList().ToPagedList(page, 9);
            return View(animevalues);
        }

        public ActionResult AnimeAdminList(int page = 1)
        {
            var animevalues = am.GetList().ToPagedList(page, 10);
            return View(animevalues);
        }
        public ActionResult AnimeAdminListDetay(int page = 1)
        {
            var animevalues = am.GetList().ToPagedList(page, 10);
            return View(animevalues);
        }

        [HttpGet]
        public ActionResult AddAnime()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAnime(Anime p)
        {
            AnimeValidator animevalidator = new AnimeValidator();
            ValidationResult result = animevalidator.Validate(p);

            if (result.IsValid)
            {
                am.AnimeAdd(p);
                return RedirectToAction("AnimeAdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult DeleteAnime(int id)
        {
            var animevalue = am.GetByID(id);
            am.AnimeDelete(animevalue);

            return RedirectToAction("AnimeAdminList");
        }
        [HttpGet]
        public ActionResult EditAnime(int id)
        {
            var animevalue = am.GetByID(id);
            return View(animevalue);

        }
        [HttpPost]
        public ActionResult EditAnime(Anime p)
        {
            am.AnimeUpdate(p);
            return RedirectToAction("AnimeAdminList");

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AnimeDetails(int id)
        {
            var animevalue = am.GetByID(id);
            return View(animevalue);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AnimeDetails(Anime p)
        {
            var animevalues = am.GetList();
            return View(animevalues);

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AnimeWatch(int id)
        {

            //var animeepisodevalue = aem.GetListById(id);
            var animeepisodevalue = aem.GetByID(id);
            return View(animeepisodevalue);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult AnimeWatch(Anime p)
        {
            //var animeepisodevalue = aem.GetListById(id);

            var animeepisodevalue = aem.GetList();
            return View(animeepisodevalue);

        }
        //[HttpGet]
        //public ActionResult AnimeEpisodeList(int id)
        //{
        //    var animeepisodevalue = aem.GetByID(id);
        //    return View(animeepisodevalue);
        //}
        //[HttpPost]
        //public ActionResult AnimeEpisodeList(AnimeEpisode p)
        //{
        //    var animeepisodevalue = aem.GetList();
        //    return View(animeepisodevalue);

        //}
        [AllowAnonymous]
        public ActionResult AnimeEpisodeList(int id)
        {
            var animeepisodevalue = aem.GetListById(id);
            return View(animeepisodevalue);
        }

        [AllowAnonymous]
        public ActionResult AnimeEpisodeListAdmin(int page = 1)
        {
            var animeepisodevalue = aem.GetList().ToPagedList(page, 15);
            return View(animeepisodevalue);
        }

        //
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddAnimeEpisode()
        {
            List<SelectListItem> valueanimeep = (from x in am.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.AnimeName,
                                                     Value = x.AnimeID.ToString()
                                                 }).ToList();

            ViewBag.vla = valueanimeep;

            return View();
        }

        [HttpPost]
        public ActionResult AddAnimeEpisode(AnimeEpisode p)
        {
            AnimeEpisodeValidator animeepisodevalidator = new AnimeEpisodeValidator();
            ValidationResult result = animeepisodevalidator.Validate(p);

            if (result.IsValid)
            {
                aem.AnimeEpAdd(p);
                return RedirectToAction("AnimeAdminList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }





        public ActionResult DeleteAnimeEpisode(int id)
        {
            var animeepvalue = aem.GetByID(id);
            aem.AnimeEpDelete(animeepvalue);

            return RedirectToAction("AnimeEpisodeListAdmin");
        }
        [HttpGet]
        public ActionResult EditAnimeEpisode(int id)
        {
            List<SelectListItem> valueanime = (from x in aem.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.Anime.AnimeName,
                                                      Value = x.AnimeID.ToString()
                                                  }).ToList();
            ViewBag.vla = valueanime;

            var animeepvalue = aem.GetByID(id);
            return View(animeepvalue);


            //var animeepvalue = am.GetByID(id);
            //return View(animeepvalue);

        }
        [HttpPost]
        public ActionResult EditAnimeEpisode(AnimeEpisode p)
        {
            aem.AnimeEpUpdate(p);
            return RedirectToAction("AnimeEpisodeListAdmin");

        }
    }
}