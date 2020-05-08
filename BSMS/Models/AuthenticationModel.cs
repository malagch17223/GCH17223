using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class AuthenticationModel
    {

        private static bsms_service services = new bsms_service();

        //Authenticate user
        public static USER AuthenticateUser(String username , String password)
        {
            USER user = null;
            foreach(USER u in services.GetUsers())
            {
                if ((u.USERNAME == username || u.EMAIL == username) && MD5_Encoding.VerifyHash(password,u.PASSWORDHASH) )
                {
                    user = u;
                    break;
                }
            }

            return user;
        }

        public static List<USER> GetStaffs()
        {
            return services.GetUsers().ToList();
        }

        public static void DeleteUser(int id)
        {
            services.DeleteUser(id);
        }

        public static void UpdateUser(USER user)
        {
            services.UpdateUser(user);
        }


        //insert new Users into the system
        public static USER AddUser(USER user)
        {
            user.PASSWORDHASH = MD5_Encoding.Encode(user.PASSWORDHASH);
            return services.AddUser(user);
        }

        public static bool EmailExist(string email)
        {
            foreach(USER u in services.GetUsers())
            {
                if (u.EMAIL.ToLower() == email.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public static bool VerifyUserHash(string hash)
        {
            foreach (USER u in services.GetUsers())
            {
                if (u.PASSWORDHASH.ToLower() == hash.ToLower().Trim())
                {
                    return true;
                }
            }
            return false;
        }

        public static USER FindUser(int userID)
        {
            foreach (USER u in services.GetUsers())
            {
                if (u.USERID == userID)
                {
                    return u; ;
                }
            }
            return null;
        }

        public static void ChangePassword(USER user)
        {
            user.PASSWORDHASH = MD5_Encoding.Encode(user.PASSWORDHASH);
            services.UpdateUser(user);
        }

        public static USER FindUserByEmail(string email)
        {
            foreach (USER u in services.GetUsers())
            {
                if (u.EMAIL.ToLower() == email.ToLower())
                {
                    return u; ;
                }
            }
            return null;
        }
    }

 
}

