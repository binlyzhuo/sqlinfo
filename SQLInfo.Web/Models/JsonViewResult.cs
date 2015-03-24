using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SQLInfo.Web.Models
{
    public class JsonViewResult
    {
        public bool Success { set; get; }
        public string Msg { set; get; }
    }
}