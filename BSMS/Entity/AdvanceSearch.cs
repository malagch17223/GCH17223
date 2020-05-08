using BSMS.bsms.localhost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BSMS.Entity
{
    public class AdvanceSearch
    {
        public string isbnNumber { get; set; }
        public string name { get; set; }
        List<PRODUCER> producers { get; set; }
        List<BOOK> books { get; set; }
        List<AUTHOR> authors { get; set; } 
    }
}