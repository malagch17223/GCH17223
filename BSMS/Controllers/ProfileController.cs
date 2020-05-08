using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Models;
using BSMS.Session;
using BSMS.Utill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Controllers
{
    public class ProfileController : Controller
    {
        private SessionHandler loginSession = new SessionHandler();
        // GET: Profile
        public ActionResult EditProfile()
        {
            if (loginSession.AuthenticatedUser() == null)
            {
                return RedirectToAction("Login", "Authentication");
            }
            USER user = AuthenticationModel.FindUser(loginSession.AuthenticatedUser().USERID);
            return View(user);
        }
        [HttpPost]
        public ActionResult EditProfile(USER user)
        {
            if (ModelState.IsValid)
            {
                AuthenticationModel.UpdateUser(user);
            }
            return RedirectToAction("EditProfile");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string password,string oldPassword,  bool keepSignIn=false)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (MD5_Encoding.Encode(oldPassword) != loginSession.AuthenticatedUser().PASSWORDHASH)
                    {
                        ViewBag.ErrorMessage = ErrorMessage.INCORRECT_USER_PASSWORD + " " + password;
                        return View();
                    }
                    USER user = loginSession.AuthenticatedUser();
                    user.PASSWORDHASH = password;
                    ViewBag.Message = SuccessMessage.PASSWORD_CHANGED + "" + loginSession.AuthenticatedUser().USERID;

                    AuthenticationModel.ChangePassword(user);
                    if (!keepSignIn)
                    {
                        return RedirectToAction("logout", "Authentication");
                    }
                    return View();
                }
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult ChangeAvatar(HttpPostedFileBase profileImage)
        {
            USER user = AuthenticationModel.FindUser(loginSession.AuthenticatedUser().USERID);
            
            String fname = Generator.RandomString(10) + "." + profileImage.FileName.Split('.')[profileImage.FileName.Split('.').Length - 1];
            string path = Server.MapPath("~/UserImages/") + fname;
            user.THUMBNAIL_PATH = "/UserImages/" + fname;
            profileImage.SaveAs(path);
            AuthenticationModel.UpdateUser(user);
            return RedirectToAction("EditProfile");
        }
    }
}