using AutoMapper;
using BLL.Interfaces;
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
        private readonly ITopicService _topicService;
        private readonly IPictureService _pictureService;
        private readonly IAudioService _audioService;
        private readonly IMapper _mapper;

        public HomeController(ITopicService serviceTopic, IPictureService servicePicture, IAudioService serviceAudio, IMapper mapper)
        {
            _mapper = mapper;
            _topicService = serviceTopic;
            _pictureService = servicePicture;
            _audioService = serviceAudio;
        }

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
                    return RedirectToAction("Contact", "Home");
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "There are some problem in sending Email";
            }
            return View();
        }

        public ActionResult GetRoles()
        {
            var role = GetActiveUserRole();
            return View(role);
        }

        public ActionResult StartLearn(int? id)
        {
            var allTopics = _topicService.GetAll();
            var topics = _mapper.Map<IEnumerable<TopicViewModel>>(allTopics);
            ViewBag.Topics = topics;
            //PictureAudio pictureAudio = new PictureAudio();
            ViewBag.NameTopic = topics.Where(x => x.Id == id);
            

            var allAudios = _audioService.GetAll();
            var audios = _mapper.Map<IEnumerable<AudioViewModel>>(allAudios);
            audios = audios.Where(x => x.TopicViewModelId == id);
            ViewBag.Audios = audios;


            var allPictures = _pictureService.GetAll();
            var pictures = _mapper.Map<IEnumerable<PictureViewModel>>(allPictures);
            pictures = pictures.Where(x => x.TopicViewModelId == id);
            ViewBag.Pictures = pictures;

            int[] listRnd = new int[3];

            Random rnd = new Random();

            int rndPicture=0;
            if (id == 1)
            {
                rndPicture = rnd.Next(1, 11);
            }
            else if (id == 2)
            {
                rndPicture = rnd.Next(1002, 1012);
            }
            else 
            {
                rndPicture = rnd.Next(1012, 1021);
            }
            ViewBag.RndPicture1 = pictures.Where(x => x.Id == rndPicture);
            ViewBag.RndAudio1 = audios.Where(x => x.Id == rndPicture);

            listRnd[0] = rndPicture;
            for (int i = 1; i <= 2; i++)
            {
                int x = 0;
                if (id == 1)
                {
                    x = rnd.Next(1, 11);
                }
                else
                if (id == 2)
                {
                    x = rnd.Next(1002, 1012);
                }
                else
                {
                    x = rnd.Next(1012, 1021);
                }
                while (x == listRnd[0] || x == listRnd[1])
                {
                    if (id == 1)
                    {
                        x = rnd.Next(1, 11);
                    }
                    else
                    if (id == 2)
                    {
                        x = rnd.Next(1002, 1012);
                    }
                    else
                    {
                        x = rnd.Next(1012, 1021);
                    }
                }
                listRnd[i] = x;
            }

            ViewBag.RndPicture2 = pictures.Where(x => x.Id == listRnd[1]);
            ViewBag.RndAudio2 = audios.Where(x => x.Id == listRnd[1]);
            ViewBag.RndPicture3 = pictures.Where(x => x.Id == listRnd[2]);
            ViewBag.RndAudio3 = audios.Where(x => x.Id == listRnd[2]);

            return View();
        }

        public ActionResult GetPictureByTopic()
        {
            var allTopics = _topicService.GetAll();
            var topics = _mapper.Map<IEnumerable<TopicViewModel>>(allTopics);
            ViewBag.TopicId = topics;

            return PartialView();
        }
    }
}