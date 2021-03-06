﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MessageBoard.Data;
using MessageBoard.Models;
using MessageBoard.Services;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private IMailService _mail;
        private IMessageBoardRepository _repo;

        public HomeController(IMailService mail, IMessageBoardRepository repository)
        {
            _mail = mail;
            _repo = repository;
        }

        public ActionResult Index()
        {
            var topics = _repo.GetTopics().OrderByDescending(c => c.Created).Take(25).ToList();

            return View(topics);
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
            var subject = String.Format("Contact Page: from {0} - {1}", contact.Name, contact.Email);

            if (_mail.SendMail(contact.Email, "pedro.maximiano@gmail.com", subject, contact.Message))
            {
                ViewBag.MailSent = true;
            }

            return View();
        }

        [Authorize]
        public ActionResult MyMessages()
        {
            return View();
        }

        [Authorize(Users = "pedro.maximiano@gmail.com")]
        public ActionResult Moderation()
        {
            return View();
        }
    }
}