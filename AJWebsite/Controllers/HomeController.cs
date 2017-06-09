using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using AJWebsite.Models;
using System.Text;

namespace AJWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.NavClassHome = "active";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";
            ViewBag.NavClassAbout = "active";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";
            ViewBag.NavClassContact = "active";
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModels c)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(c.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("garcia-aguilera4454@student.cptc.edu");
                    msg.Subject = "Contact Us";
                    msg.IsBodyHtml = false;
                    smtp.Host = "mail.yourdomain.com";
                    smtp.Port = 25;
                    sb.Append("First name: " + c.FirstName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Last name: " + c.LastName);
                    sb.Append(Environment.NewLine);
                    sb.Append("Email: " + c.Email);
                    sb.Append(Environment.NewLine);
                    sb.Append("Message: " + c.Message);
                    msg.Body = sb.ToString();
                    smtp.Send(msg);
                    msg.Dispose();
                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View();
        }
        public ActionResult Services()
        {
            ViewBag.Message = "Our Services:";
            ViewBag.NavClassServices = "active";
            return View();
        }

    }
}