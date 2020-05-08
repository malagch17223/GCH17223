using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class GenreController : Controller
    {
        // GET: Genre
        public ActionResult Index()
        {
            return View(GenreModel.GetGenre());
        }

        // GET: Genre/Details/5
        public ActionResult Details(int id)
        {
            return View(GenreModel.Fliter(id));
        }

        // GET: Genre/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Genre/Create
        [HttpPost]
        public ActionResult Create(GENRE genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GenreModel.AddGenre(genre);
                    ViewBag.Message = SuccessMessage.GENRE_ADDED_MESSAGE;
                }
                else
                {
                    ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
                }
                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = ErrorMessage.INTERNAL_ERROR;
                return View();
            }
        }

        // GET: Genre/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GenreModel.Fliter(id));
        }

        // POST: Genre/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, GENRE genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    GenreModel.Update(genre);
                    ViewBag.Message = SuccessMessage.GENRE_UPDATED_MESSAGE;
                }
                else
                {
                    ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
                }

                return View();
            }
            catch
            {
                ViewBag.ErrorMessage = ErrorMessage.INTERNAL_ERROR;
                return View();
            }
        }

        // GET: Genre/Delete/5
        public ActionResult Delete(int id)
        {
            GenreModel.Delete(id);
            return RedirectToAction("index");
        }

        
    }
}
