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
    public class WordController : Controller
    {
        private readonly IWordService _wordService;
        private readonly IMapper _mapper;

        public WordController(IWordService service, IMapper mapper)
        {
            _mapper = mapper;
            _wordService = service;
        }
        // GET: Word
        public ActionResult Index()
        {
            var allWords = _wordService.GetAll();
            var words = _mapper.Map<IEnumerable<WordViewModel>>(allWords);
            return View(words);
        }

        // GET: Word/Details/5
        public ActionResult Details(int id)
        {
            var wordModel = _wordService.GetById(id);
            var wordViewModel = _mapper.Map<WordViewModel>(wordModel);
            return View(wordViewModel);
        }

        // GET: Word/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Word/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(WordViewModel wordViewModel)
        {
            if (ModelState.IsValid)
            {
                var wordModel = _mapper.Map<WordModel>(wordViewModel);
                _wordService.Add(wordModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Word/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Word/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, WordViewModel wordViewModel)
        {
            if (ModelState.IsValid)
            {
                var wordModel = _mapper.Map<WordModel>(wordViewModel);
                _wordService.Update(wordModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Word/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Word/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, WordViewModel wordViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _wordService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
