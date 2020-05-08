using BSMS.bsms.localhost;
using BSMS.Models;
using BSMS.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class WishListController : Controller
    {
        private SessionHandler loginSession = new SessionHandler();
        // GET: WishList
        public ActionResult Index(int? id)
        {
            return View(WishListModel.GetAll(id));
        }

        public ActionResult AddToWishList(int id)
        {
            BOOK book = BookModel.FilterBook(id);
            if (book == null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            if (!WishListModel.Exist(id, loginSession.AuthenticatedUser().USERID))
            {
                WishListModel.AddToWishList(id, loginSession.AuthenticatedUser().USERID);
            }
            
            return Json(WishListModel.CountWishList(loginSession.AuthenticatedUser().USERID),JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult RemoveWishList(int id)
        {
            WishListModel.RemoveWishList(id);
            return Json(WishListModel.CountWishList(loginSession.AuthenticatedUser().USERID), JsonRequestBehavior.AllowGet);
        }

    }
}