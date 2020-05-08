using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BSMS.Models;
using BSMS.bsms;
using BSMS.bsms.localhost;
using BSMS.Message;
using BSMS.Session;
using BSMS.Utill;

namespace BSMS.Controllers
{
    public class AuthenticationController : Controller
    {
        private SessionHandler LoginSession = new SessionHandler();
        public ActionResult Login()
        {
            
            return View();
        }
        //login post back handler
        [HttpPost]
        public ActionResult Login(String username, String password)
        {
            if (ModelState.IsValid)
            {
                USER user = AuthenticationModel.AuthenticateUser(username, password);

                if (user == null)
                {
                    ViewBag.ErrorMessage = ErrorMessage.INVALID_LOGIN;
                    return View();
                }

                LoginSession.LoginSession(user);

                if (LoginSession.ISAdmin())
                {
                    return RedirectToAction("DashBoard", "Home");
                }
                else if (LoginSession.ISStaff())
                {
                    return RedirectToAction("Index", "Book");
                }
                else if (LoginSession.ISCustomer())
                {
                    return RedirectToAction("BookList", "Book");
                }

            }
            return View();

        }

        //logout action
        public ActionResult Logout()
        {
            if (!LoginSession.ISGuest())
            {
                LoginSession.ClearSession();
            }
            return RedirectToAction("Login");
        }

        public ActionResult RegisterClient()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterClient(USER user, HttpPostedFileBase thumbnail)
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
                user.ROLEID = LoginSession.ISAdmin() ? UserRole.STAFF : UserRole.CUSTOMER;

                AuthenticationModel.AddUser(user);
                if (LoginSession.ISAdmin())
                {
                    EmailNotification.ForgetPassword(user.EMAIL, user.PASSWORDHASH, user.USERID);
                }
                ViewBag.Message = SuccessMessage.REGISTERATION_COMPLETED;
            }
            else
            {
                ViewBag.ErrorMessage = ErrorMessage.REQUIRED_ASTERIC_FIELDS;
            }
            return View();

        }


        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPassword(String Email)
        {
            if (AuthenticationModel.EmailExist(Email))
            {
                USER user = AuthenticationModel.FindUserByEmail(Email);
                EmailNotification.ForgetPassword(user.EMAIL, user.PASSWORDHASH, user.USERID);
                ViewBag.Message = SuccessMessage.EMAIL_SENT;

            }
            else
            {
                ViewBag.ErrorMessage = ErrorMessage.EMAIL_ERROR_MESSAGE;
            }
            return View();
        }

        public ActionResult ResetPassword(String hash, int userID)
        {
            if (hash.Length != 32 || !AuthenticationModel.VerifyUserHash(hash))
            {
                ViewBag.ErrorMessage = ErrorMessage.INVALID_ACCESS;
                return View();
            }

            return View();

        }

        [HttpPost]
        public ActionResult ResetPassword(String hash, int userID, String password)
        {
            USER user = AuthenticationModel.FindUser(userID);
            if (user != null && ModelState.IsValid)
            {
                user.PASSWORDHASH = password;
                AuthenticationModel.ChangePassword(user);
                ViewBag.Message = SuccessMessage.PASSWORD_CHANGED;
            }
            else
            {
                ViewBag.ErrorMessage = ErrorMessage.PASSWORD_CHANGED;
            }
            return View();
        }
    }
}