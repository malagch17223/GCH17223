using BSMS.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSMS.Controllers
{
    public class BSMSController<T> : ContentValidator <T>
    {
        public string jsonResultMessage { get; set; }
        public Boolean validContent(T entity)
        {
            return !(entity == null);
        }

        public bool ErrorExist {
            get
            {
                return jsonResultMessage != "";
            }
        }
    }
}