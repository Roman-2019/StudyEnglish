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
    public class PictureController : Controller
    {

        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public PictureController(IPictureService service, IMapper mapper)
        {
            _mapper = mapper;
            _pictureService = service;
        }

        // GET: Picture
        public ActionResult Index()
        {
            var allPictures = _pictureService.GetAll();
            var pictures = _mapper.Map<IEnumerable<PictureViewModel>>(allPictures);
            return View(pictures);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            var pictureModel = _pictureService.GetById(id);
            var pictureViewModel = _mapper.Map<PictureViewModel>(pictureModel);
            return View(pictureViewModel);
        }

        // GET: Picture/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Picture/Create
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Create(PictureViewModel pictureViewModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(pictureViewModel.ImageFile.FileName);
            string extention = Path.GetExtension(pictureViewModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extention;
            pictureViewModel.ImagePath = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            pictureViewModel.ImageFile.SaveAs(fileName);
            //using (DBContext pc_db = new DBContext())
            //{
            //    var pictureModel = _mapper.Map<PictureModel>(pictureViewModel);
            //    var picModel = _mapper.Map<Picture>(pictureModel);
            //    pc_db.Pictures.Add(picModel);
            //    pc_db.SaveChanges();
            //}
            if (ModelState.IsValid)
            {
                var pictureModel = _mapper.Map<PictureModel>(pictureViewModel);
                _pictureService.Add(pictureModel);
                //ViewBag.ActiveUserRole = GetActiveUserRole();
                return RedirectToAction("Index");
            }

            ModelState.Clear();
            return View();
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Picture/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, PictureViewModel pictureViewModel)
        {
            if (ModelState.IsValid)
            {
                // TODO: Add update logic here
                var pictureModel = _mapper.Map<PictureModel>(pictureViewModel);
                _pictureService.Update(pictureModel);
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Picture/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int id, PictureViewModel pictureViewModel)
        {
            try
            {
                // TODO: Add delete logic here
                _pictureService.Remove(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
