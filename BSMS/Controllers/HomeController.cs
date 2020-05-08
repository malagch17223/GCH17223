using BSMS.bsms.localhost;
using BSMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(BookModel.GetBooks());
        }

        public ActionResult AutoComplete(string keyword)
        {
            List<BOOK> match = new List<BOOK>();
            int cnt = 0;
            foreach(BOOK book in BookModel.GetBooks())
            {
                if (book.NAME.ToLower().Contains(keyword.ToLower()))
                {
                    match.Add(book);
                    cnt++;
                }
                if (cnt >= 4)
                {
                    break;
                }
            }
            return Json(match, JsonRequestBehavior.AllowGet);
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


        public ActionResult DashBoard()
        {
            return View();
        }
    }
}