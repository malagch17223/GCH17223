using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BSMS.bsms.localhost;

namespace BSMS.Models
{
    public class CategoryModel
    {
        private static bsms_service Services = new bsms_service();
        public static bool AddCategory(CATEGORY category)
        {
            Services.InserCategory(category);
            return true;
        }

        public static List<CATEGORY> GetAllCategory()
        {
           return Services.GetCategories().ToList();
        }

        public static void EditCategory(CATEGORY category)
        {
            Services.UpdateCategory(category);
        }

        public static CATEGORY Fliter(int id)
        {
            foreach(CATEGORY cat in GetAllCategory())
            {
                if (cat.CATEGORYID == id)
                {
                    return cat;
                }
            }
            return null;
        }

        public static void DeleteCategory(int id)
        {
            Services.DeleteCategory(id);
        }

        public static bool AddBookCategory(BOOK_CATEGORY bookCategory)
        {
            Services.InsertBookCategory(bookCategory);
            return true;
        }
    }
}