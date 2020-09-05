using AutoMapper;
using BLL.Interfaces;
using BLL.Models;
using SEnglish.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEnglish.Controllers
{
    public class AudiosController : Controller
    {
        private readonly IAudioService _audioService;
        private readonly IMapper _mapper;

        public AudiosController(IAudioService service, IMapper mapper)
        {
            _mapper = mapper;
            _audioService = service;
        }
        // GET: Audio
        public ActionResult Index()
        {
            var allAudios = _audioService.GetAll();
            var audios = _mapper.Map<IEnumerable<AudioViewModel>>(allAudios);
            return View(audios);
        }

        // GET: Audio/Details/5
        public ActionResult Details(int id)
        {
            var audioModel = _audioService.GetById(id);
            var audioViewModel = _mapper.Map<AudioViewModel>(audioModel);
            return View(audioViewModel);
        }

        // GET: Audio/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Audio/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(AudioViewModel audioViewModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(audioViewModel.AudioFile.FileName);
            string extention = Path.GetExtension(audioViewModel.AudioFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            audioViewModel.AudioPath = "~/Audio/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Audio/"), fileName);
            audioViewModel.AudioFile.SaveAs(fileName);

            if (ModelState.IsValid)
            {
                var audioModel = _mapper.Map<AudioModel>(audioViewModel);
                _audioService.Add(audioModel);
                //ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }

            ModelState.Clear();
            return View();
        }

        // GET: Audio/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Audio/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, AudioViewModel audioViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var audioModel = _mapper.Map<AudioModel>(audioViewModel);
                _audioService.Update(audioModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Audio/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Audio/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, AudioViewModel audioViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _audioService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
