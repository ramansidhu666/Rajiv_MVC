using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Rajiv_MVC.Controllers
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
        public ActionResult FAQ()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Privacy()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }

          [HttpPost]
        public ActionResult Contact(string username, string lastname, string Email, string phn, string message)
        {
            bool isSent = SendMail(username+ " " +lastname, Email, phn, message);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public bool SendMail(string Name, string Email, string Phone, string Message)
        {

            MailMessage message = new MailMessage();
            message.To.Add(WebConfigurationManager.AppSettings["ToEmailID"]);
            message.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.Subject = "Contact Mail";

            string body = "";
            body = "<p>Person Name : " + Name + "</p>";
            body = body + "<p>Email ID : " + Email + "</p>";
            body = body + "<p>Phone No : " + Phone + "</p>";
            body = body + "<p>Message : " + Message + "</p>";
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient(WebConfigurationManager.AppSettings["smtp"]);
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["FromEmailID"], WebConfigurationManager.AppSettings["FromEmailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;

        }
        public bool SendMailSelling(string Name, string Email, string Phone, string street, string unit, string streetName, string city)
        {

            MailMessage message = new MailMessage();
            message.To.Add(WebConfigurationManager.AppSettings["ToEmailID"]);
            message.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.Subject = "Selling assignment";

            string body = "";
            body = "<p>Person Name : " + Name + "</p>";
            body = body + "<p>Email ID : " + Email + "</p>";
            body = body + "<p>Phone No : " + Phone + "</p>";
            body = body + "<p>street: " + street + "</p>";
            body = body + "<p>Unit: " + unit + "</p>";
            body = body + "<p>Street Name : " + streetName + "</p>";
            body = body + "<p>City : " + city + "</p>";
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient(WebConfigurationManager.AppSettings["smtp"]);

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["FromEmailID"], WebConfigurationManager.AppSettings["FromEmailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;

        }
        public bool SendMailBuying(string Name, string Email, string Phone, string street, string unit, string streetName, string city)
        {

            MailMessage message = new MailMessage();
            message.To.Add(WebConfigurationManager.AppSettings["ToEmailID"]);
            message.From = new MailAddress(WebConfigurationManager.AppSettings["FromEmailID"]);
            message.Subject = "Buying assignment";

            string body = "";
            body = "<p>Person Name : " + Name + "</p>";
            body = body + "<p>Email ID : " + Email + "</p>";
            body = body + "<p>Phone No : " + Phone + "</p>";
           
            body = body + "<p>Home Type: " + street + "</p>";
            body = body + "<p>Bedrooms: " + unit + "</p>";
            body = body + "<p>Washrooms : " + streetName + "</p>";
            body = body + "<p>City : " + city + "</p>";
            message.Body = body;
            message.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient(WebConfigurationManager.AppSettings["smtp"]);

            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential(WebConfigurationManager.AppSettings["FromEmailID"], WebConfigurationManager.AppSettings["FromEmailPassword"]);
            smtpClient.EnableSsl = true;
            smtpClient.Send(message);
            return true;

        }


        public ActionResult Buying()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult Buying(string username, string lastname, string Email, string phn, string message, string street, string unit, string streetName, string city)
        {
            if(streetName=="Washrooms")
            {
                streetName = "";
            }
            if(unit=="Bedrooms")
            {
                unit = "";
            }
            if (street == "What type of home are you looking for ?")
            {
                street = "";
            }
            bool isSent = SendMailBuying(username + " " + lastname, Email, phn, street, unit, streetName, city);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Selling()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Selling(string username, string lastname, string Email, string phn, string message,string street,string unit,string streetName,string city)
        {
            bool isSent = SendMailSelling(username + " " + lastname, Email, phn, street, unit, streetName, city);
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}