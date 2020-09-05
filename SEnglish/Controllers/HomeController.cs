using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SEnglish.Controllers
{
    public class HomeController : Controller
    {

        public IList<string> GetActiveUserRole()
        {
            IList<string> roles = new List<string> { "Роль не определена" };
            ApplicationUserManager userManager = HttpContext.GetOwinContext()
                                                    .GetUserManager<ApplicationUserManager>();
            ApplicationUser user = userManager.FindByEmail(User.Identity.Name);
            if (user != null)
                roles = userManager.GetRoles(user.Id);
            return new List<string>(roles);
        }

        public ActionResult Index()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
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

        public ActionResult SendEmail()
        {
            ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult SendEmail(string yourEmail, string subject, string message)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var fromAddress = new MailAddress("admforum428@gmail.com", yourEmail);
                    var toAddress = new MailAddress("bardlesswk@gmail.com", "Send from forum");

                    var usr = User.Identity.Name;
                    var password = "Adminforum123";
                    var sub = subject;
                    var body = message + " From " + usr + " on " + yourEmail;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, password)
                    };

                    using (var mess = new MailMessage(fromAddress.Address, toAddress.Address)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                    //ViewBag.ActiveUserRole = GetActiveUserRole();
                    return RedirectToAction("Contact", "Home");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "There are some problem in sending Email";
            }
            //ViewBag.ActiveUserRole = GetActiveUserRole();
            return View();
        }
    }
}