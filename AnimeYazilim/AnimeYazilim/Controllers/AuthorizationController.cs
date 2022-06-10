using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using EntityLayer.Dextra;

namespace AnimeYazilim.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EfAdminDal());
        RoleManager roleManager = new RoleManager(new EfRoleDal());
        IAuthorizationService authService = new AuthorizationManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        public ActionResult Index(int page = 1)
        {
            var adminvalues = am.GetList().ToPagedList(page, 6);
            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            //List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
            //                                       select new SelectListItem
            //                                       {
            //                                           Text = c.RoleName,
            //                                           Value = c.RoleId.ToString()

            //                                       }).ToList();

            //ViewBag.valueadmin = valueadminrole;
            //return View();
            //2 farklı opsiyon kullanacagım üstteki başka bir deneme için buna bağlı olarak postunda üstü değişecek elbette

            return View();
        }
        //[HttpPost]
        //public ActionResult AddAdmin(LoginDto loginDto)
        //{
        //    authService.Register(loginDto.AdminUserName, loginDto.AdminPassword);
        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteAdmin(int id)
        {
            //var result = am.GetByID(id);
            //if (result.Status == true)
            //{
            //    result.Status = false;
            //}
            //else
            //{
            //    result.Status = true;
            //}
            //am.AdminUpdate(result);
            //return RedirectToAction("Index");

            var adminvalues = am.GetByID(id);
            am.AdminDelete(adminvalues);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public ActionResult EditAdmin(int id)
        //{
        //    List<SelectListItem> valueadminrole = (from c in roleManager.GetRoles()
        //                                           select new SelectListItem
        //                                           {
        //                                               Text = c.RoleName,
        //                                               Value = c.RoleId.ToString()

        //                                           }).ToList();

        //    ViewBag.valueadmin = valueadminrole;
        //    var result = am.GetByID(id);
        //    return View(result);

        //}
        //[HttpPost]
        //public ActionResult EditAdmin(Admin p)
        //{
        //    p.Status = true;
        //    am.AdminUpdate(p);
        //    return RedirectToAction("Index");

        //}


        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalues = am.GetByID(id);
            return View(adminvalues);

        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult ChangeAdminStatus(int id)
        {
            var result = am.GetByID(id);
            if (result.Status)
            {
                result.Status = false;
            }
            else
            {
                result.Status = true;
            }

            am.AdminUpdate(result);
            return RedirectToAction("Index");
        }
    }
}