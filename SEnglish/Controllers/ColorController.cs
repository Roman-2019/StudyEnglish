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
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public ColorController(IColorService service, IMapper mapper)
        {
            _mapper = mapper;
            _colorService = service;
        }
        // GET: Color
        public ActionResult Index()
        {
            var allColors = _colorService.GetAll();
            var colors = _mapper.Map<IEnumerable<ColorViewModel>>(allColors);
            return View(colors);
        }

        // GET: Color/Details/5
        public ActionResult Details(int id)
        {
            var colorModel = _colorService.GetById(id);
            var colorViewModel = _mapper.Map<ColorViewModel>(colorModel);
            return View(colorViewModel);
        }

        // GET: Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(ColorViewModel colorViewModel)
        {
            if (ModelState.IsValid)
            {
                var colorModel = _mapper.Map<ColorModel>(colorViewModel);
                _colorService.Add(colorModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Color/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Color/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, ColorViewModel colorViewModel)
        {
            if (ModelState.IsValid)
            {
                var colorModel = _mapper.Map<ColorModel>(colorViewModel);
                _colorService.Update(colorModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Color/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Color/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, ColorViewModel colorViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _colorService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
