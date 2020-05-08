using BSMS.bsms.localhost;
using BSMS.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BSMS.Validator
{
    public class ContentValidator<E> : Controller
    {
        public static String ValidBook(BOOK book)
        {
            return (!String.IsNullOrEmpty(book.NAME)) ? "Valid" : "Incorrect Book ISBN Number";
        }


        public string categoryContainsError(CATEGORY category)
        {
            string error = "";
            if (String.IsNullOrWhiteSpace(category.NAME))
            {
                error = ErrorMessage.CATEGORY_NAME_IS_NULL_OR_INVALID;
            }
            else if (String.IsNullOrWhiteSpace(category.DESCRIPTION))
            {
                error = ErrorMessage.CATEGORY_DESCRIPTION_IS_NULL_OR_INVALID;

            }
            else if (String.IsNullOrWhiteSpace(category.REFERENCE_KEY))
            {
                error = ErrorMessage.REFERENCEKEY_IS_NULL_OR_INVALID;

            }
            return error;
        }
    }
}
