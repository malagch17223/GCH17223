using BSMS.bsms.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace BSMS.Session
{
    public class SessionHandler
    {
        private static HttpSessionState Session = HttpContext.Current.Session;
 
        public void LoginSession(USER user)
        {
            Session[Constant.LOGIN_SESSION_NAME] = user;
        }

        public int GetRole()
        {
           return  (((USER)Session[Constant.LOGIN_SESSION_NAME]).ROLEID).Value;
        }


        public bool ISAdmin()
        {
            if (ISGuest())
                return false;
            return (((USER)Session[Constant.LOGIN_SESSION_NAME]).ROLE.ROLE1).ToLower() == "admin";
        }

        public bool ISCustomer()
        {
            if (ISGuest())
                return false;
            return (((USER)Session[Constant.LOGIN_SESSION_NAME]).ROLE.ROLE1).ToLower() == "customer";
        }

        public bool ISStaff()
        {
            if (ISGuest())
                return false;
            return (((USER)Session[Constant.LOGIN_SESSION_NAME]).ROLE.ROLE1).ToLower() == "staff";
        }
        public bool ISGuest()
        {
            return Session[Constant.LOGIN_SESSION_NAME] == null;
        }

        public void ClearSession()
        {
            Session[Constant.LOGIN_SESSION_NAME] = null;
        }

        public USER AuthenticatedUser()
        {
            return (((USER)Session[Constant.LOGIN_SESSION_NAME]));
        }

    }
}