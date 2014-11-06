using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            var svc = new MailService();
            var subject = String.Format("Contact Page: from {0} - {1}", contact.Name, contact.Email);

            svc.SendMail(contact.Email, "pedro.maximiano@gmail.com", subject, contact.Message);

            return View();
        }
    }
}