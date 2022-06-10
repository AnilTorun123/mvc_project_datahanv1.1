using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimeYazilim.Controllers
{
    public class MessageController : Controller
    {


        // GET: Message
        MessageManager mm = new MessageManager(new EfMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox(string p)
        {
            var messagelist = mm.GetListInbox(p);
            return View(messagelist);
        }
        public ActionResult Sendbox(string p)
        {
            var messagelist = mm.GetListSendbox(p);
            return View(messagelist);
        }
        public ActionResult GetInBoxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            //values.MessageRead = true;
            //mm.MessageUpdate(values);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetById(id);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            ValidationResult result = messagevalidator.Validate(p);
            if (result.IsValid)
            {
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAdd(p);
                return RedirectToAction("SendBox");
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

        public ActionResult Read()
        {
            string p = (string)Session["WriterMail"];
            var deger = mm.GetReadList(p);
            return View(deger);
        }

        public ActionResult UnRead()
        {
            string p = (string)Session["WriterMail"];
            var deger = mm.GetUnReadList(p);
            return View(deger);
        }

        public ActionResult Draft()
        {
            string p = (string)Session["WriterMail"];
            var deger = mm.GetListDraft(p);
            return View(deger);
        }

        public ActionResult Trash()
        {
            string p = (string)Session["WriterMail"];
            var deger = mm.GetListTrash(p);
            return View(deger);
        }
    }
}