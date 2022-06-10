using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using PagedList;
using PagedList.Mvc;


namespace AnimeYazilim.Controllers
{
    public class MangaController : Controller
    {
        // GET: Manga
        MangaManager mm = new MangaManager(new EfMangaDal());
        MangaEpisodeManager mem = new MangaEpisodeManager(new EfMangaEpisodeDal());
        Context c = new Context();
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var mangavalues = mm.GetList().ToPagedList(page, 9);
            return View(mangavalues);
        }

        public ActionResult IndexAdmin(int page = 1)
        {
            //p = (string)Session["WriterMail"];
            //var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            //var animevalues = am.GetListByWriter(writeridinfo);
            var mangavalues = mm.GetList().ToPagedList(page, 9);
            return View(mangavalues);
        }

        public ActionResult MangaAdminList(int page = 1)
        {
            var mangavalues = mm.GetList().ToPagedList(page, 10);
            return View(mangavalues);
        }
        public ActionResult MangaAdminListDetay(int page = 1)
        {
            var mangavalues = mm.GetList().ToPagedList(page, 10);
            return View(mangavalues);
        }

        [HttpGet]
        public ActionResult AddManga()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddManga(Manga p)
        {
            MangaValidator mangavalidator = new MangaValidator();
            ValidationResult result = mangavalidator.Validate(p);

            if (result.IsValid)
            {
                mm.MangaAdd(p);
                return RedirectToAction("MangaAdminList");
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
        public ActionResult DeleteManga(int id)
        {
            var animevalue = mm.GetByID(id);
            mm.MangaDelete(animevalue);

            return RedirectToAction("MangaAdminList");
        }
        [HttpGet]
        public ActionResult EditManga(int id)
        {
            var mangavalues = mm.GetByID(id);
            return View(mangavalues);

        }
        [HttpPost]
        public ActionResult EditManga(Manga p)
        {
            mm.MangaUpdate(p);
            return RedirectToAction("MangaAdminList");

        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult MangaDetails(int id)
        {
            var mangavalues = mm.GetByID(id);
            return View(mangavalues);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult MangaDetails(Manga p)
        {
            var mangavalues = mm.GetList();
            return View(mangavalues);

        }


        ///

        [AllowAnonymous]
        public ActionResult MangaEpisodeList(int id)
        {
            var animeepisodevalue = mem.GetListById(id);
            return View(animeepisodevalue);
        }

        [AllowAnonymous]
        public ActionResult MangaEpisodeListAdmin(int page = 1)
        {
            var animeepisodevalue = mem.GetList().ToPagedList(page, 15);
            return View(animeepisodevalue);
        }

        //
        [AllowAnonymous]
        [HttpGet]
        public ActionResult AddMangaEpisode()
        {
            List<SelectListItem> valuemangaep = (from x in mm.GetList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.MangaName,
                                                     Value = x.MangaID.ToString()
                                                 }).ToList();

            ViewBag.vla = valuemangaep;

            return View();
        }

        [HttpPost]
        public ActionResult AddMangaEpisode(MangaEpisode p)
        {
            MangaEpisodeValidator mangaepisodevalidator = new MangaEpisodeValidator();
            ValidationResult result = mangaepisodevalidator.Validate(p);

            if (result.IsValid)
            {
                mem.MangaEpAdd(p);
                return RedirectToAction("MangaAdminList");
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





        public ActionResult DeleteMangaEpisode(int id)
        {
            var mangaepvalue = mem.GetByID(id);
            mem.MangaEpDelete(mangaepvalue);

            return RedirectToAction("MangaEpisodeListAdmin");
        }
        [HttpGet]
        public ActionResult EditMangaEpisode(int id)
        {
            List<SelectListItem> valuemanga = (from x in mem.GetList()
                                               select new SelectListItem
                                               {
                                                   Text = x.Manga.MangaName,
                                                   Value = x.MangaID.ToString()
                                               }).ToList();
            ViewBag.vla = valuemanga;

            var mangaepvalue = mem.GetByID(id);
            return View(mangaepvalue);
        }

        [HttpPost]
        public ActionResult EditMangaEpisode(MangaEpisode p)
        {
            mem.MangaEpUpdate(p);
            return RedirectToAction("MangaEpisodeListAdmin");

        }
    }

}
