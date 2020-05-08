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
    public class ProducerController : Controller
    {
        // GET: Producer
        public ActionResult Index()
        {
            return View(ProducerModel.GetProducers());
        }


        /// <summary>
        //List producers (HttpGet)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Producer()
        {
            return View(ProducerModel.GetProducers());
        }


        // GET: Producer/Details/5
        public ActionResult Details(int id)
        {
            return View(ProducerModel.Filter(id));
        }

        // GET: Producer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producer/Create
        [HttpPost]
        public ActionResult Create(PRODUCER producer)
        {
            try
            {
               if (ModelState.IsValid)
                {
                    ProducerModel.Create(producer);
                    ViewBag.Message = SuccessMessage.PRODUCER_CREATED;
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

        // GET: Producer/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ProducerModel.Filter(id));
        }

        // POST: Producer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PRODUCER producer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProducerModel.Update(producer);
                    ViewBag.Message = SuccessMessage.PRODUCER_EDITED;
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

        // GET: Producer/Delete/5
        public ActionResult Delete(int id)
        {
            ProducerModel.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
