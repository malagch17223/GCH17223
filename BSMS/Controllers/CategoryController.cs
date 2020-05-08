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
    public class CategoryController : BSMSController<CATEGORY>
    {
        public ActionResult Index()
        {
            return View(CategoryModel.GetAllCategory());
        }

        // GET: Catrgory/Details/5
        public ActionResult Details(int id)
        {
            return View(CategoryModel.Fliter(id));
        }

        // GET: Catrgory/Create
        public ActionResult Create()
        {
            return View();
        }



        // POST: Catrgory/Create
        [HttpPost]
        public ActionResult Create(CATEGORY category)
        {
            try
            {
                jsonResultMessage = categoryContainsError(category);
                if (jsonResultMessage == "")
                {
                    CategoryModel.AddCategory(category);
                }
            }
            catch
            {
                jsonResultMessage = ErrorMessage.INTERNAL_ERROR;
            }

            return Json(jsonResultMessage == "" ? "" : jsonResultMessage, JsonRequestBehavior.AllowGet);
        }

        // GET: Catrgory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CategoryModel.Fliter(id));
        }

        // POST: Catrgory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CATEGORY category)
        {
            try
            {
                jsonResultMessage = categoryContainsError(category);
                if (ModelState.IsValid && !ErrorExist)
                {
                    CategoryModel.EditCategory(category);  
                }
                return Json(jsonResultMessage, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Error", JsonRequestBehavior.AllowGet);
            }
        }

        // Post: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryModel.DeleteCategory(id);
            return RedirectToAction("index");
        }

    }
}
