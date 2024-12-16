using CLB_TinHoc_64131060.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CLB_TinHoc_64131060.Controllers
{
    public class Email_64131060Controller : Controller
    {
        // GET: Email_Assitant_64131060
        //Gửi email
        public ActionResult SendMail_Asstant_64131060()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail_Asstant_64131060(Email_64131060 model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("MailAlert1_64131060");
        }
        public ActionResult MailAlert1_64131060(Email_64131060 model)
        {
            return View();
        }

        public ActionResult SendMail_Admin_64131060()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail_Admin_64131060(Email_64131060 model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("MailAlert2_64131060");
        }
        public ActionResult MailAlert2_64131060(Email_64131060 model)
        {
            return View();
        }

        public ActionResult SendMail_Member_64131060()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendMail_Member_64131060(Email_64131060 model)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.From = new System.Net.Mail.MailAddress(model.From);
            mail.To.Add(model.To);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = true;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential(model.From, model.Password);
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return View("MailAlert3_64131060");
        }

        public ActionResult MailAlert3_64131060(Email_64131060 model)
        {
            return View();
        }
    }
}