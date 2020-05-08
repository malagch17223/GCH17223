using BSMS.bsms.localhost;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSMS.Models
{
    public class LanguageModel
    {
        private static bsms_service Service = new bsms_service();
        internal static IEnumerable<LANGUAGE> GetLanguages()
        {
            return Service.GetLanguages();
        }
    }
}