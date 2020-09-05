using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using SEnglish.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEnglish.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicController(ITopicService service, IMapper mapper)
        {
            _mapper = mapper;
            _topicService = service;
        }
        // GET: Topic
        public ActionResult Index()
        {
            var allTopics = _topicService.GetAll();
            var topics = _mapper.Map<IEnumerable<TopicViewModel>>(allTopics);
            return View(topics);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            var topicModel = _topicService.GetById(id);
            var topicViewModel = _mapper.Map<TopicViewModel>(topicModel);
            return View(topicViewModel);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(TopicViewModel topicViewModel)
        {
            if (ModelState.IsValid)
            {
                var topicModel = _mapper.Map<TopicModel>(topicViewModel);
                _topicService.Add(topicModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Topic/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Topic/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, TopicViewModel topicViewModel)
        {
            if (ModelState.IsValid)
            {
                var topicModel = _mapper.Map<TopicModel>(topicViewModel);
                _topicService.Update(topicModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Topic/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Topic/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, TopicViewModel topicViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _topicService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
