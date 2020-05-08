using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using BSMS.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class StaffController : Controller
    {
      
        //GET : Staff //List of all staff
        public ActionResult Index()
        {
            return View(AuthenticationModel.GetStaffs());
        }

        // GET: Staff
        public ActionResult ViewProfile(int id)
        {
            return View(AuthenticationModel.FindUser(id));
        }

        // GET: Staff/Details/5
        public ActionResult UpdateStaff(int id)
        {
            return View(AuthenticationModel.FindUser(id));
        }


        // POST: Staff/Details/5
        [HttpPost]
        public ActionResult UpdateStaff(int id, USER user, HttpPostedFileBase thumbnail)
        {
            if (ModelState.IsValid)
            {
                if (thumbnail != null && !String.IsNullOrEmpty(thumbnail.FileName))
                {
                    String fname = Generator.RandomString(10) + "." + thumbnail.FileName.Split('.')[thumbnail.FileName.Split('.').Length - 1];
                    string path = Server.MapPath("~/UserImages/") + fname;
                    user.THUMBNAIL_PATH = "/UserImages/" + fname;
                    thumbnail.SaveAs(path);
                }
                else
                {
                    user.THUMBNAIL_PATH = AuthenticationModel.FindUser(id).THUMBNAIL_PATH;
                }
                AuthenticationModel.UpdateUser(user);
                ViewBag.Message = ErrorMessage.USER_UPDATED;
            }
            else
            {
                ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
            }
            return View();
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            USER user = AuthenticationModel.FindUser(id);
            AuthenticationModel.DeleteUser(id);

            EmailNotification.AccountDeletedNotification(user);

            return RedirectToAction("index");
        }

        
        public ActionResult AddStaff()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStaff(USER user, HttpPostedFileBase thumbnail)
        {
            if (ModelState.IsValid && !String.IsNullOrEmpty(user.PASSWORDHASH))
            {
                if (thumbnail != null && !String.IsNullOrEmpty(thumbnail.FileName))
                {
                    String fname = Generator.RandomString(10) + "." + thumbnail.FileName.Split('.')[thumbnail.FileName.Split('.').Length - 1];
                    string path = Server.MapPath("~/UserImages/") + fname;
                    user.THUMBNAIL_PATH = "/UserImages/" + fname;
                    thumbnail.SaveAs(path);
                }
                user.ROLEID = UserRole.STAFF;

                AuthenticationModel.AddUser(user);
               
                    EmailNotification.ForgetPassword(user.EMAIL, user.PASSWORDHASH, user.USERID);
               
                ViewBag.Message = SuccessMessage.REGISTERATION_COMPLETED;
            }
            else
            {
                ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
            }
            return View();

        }

    }
}
