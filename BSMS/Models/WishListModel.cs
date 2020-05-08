using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class WishListModel
    {
        private static bsms_service localhost = new bsms_service(); 
        internal static void AddToWishList(int bookId, int uSERID)
        {
            localhost.AddWishList(uSERID, bookId);
        }

        public static int CountWishList(int uSERID)
        {
            return localhost.GetWishList(uSERID).Count();
        }

        internal static List<WATCHLIST> GetAll(int? id)
        {
            return localhost.GetWishList(id.Value).ToList();
        }

        public static bool Exist(int id, int uSERID)
        {
            foreach (WATCHLIST item in localhost.GetWishList(uSERID))
            {
                if (item.BOOKID.Value == id) {
                    return true;
                }
            }
            return false;
        }

        internal static void RemoveWishList(int id)
        {
            localhost.DeleteWishList(id);
        }
    }
}