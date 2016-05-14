using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.BlogDAL.Entities
{
    public class Blog
    {
        public int BlogID { get; set; }
        public int UserID { get; set; }
        public string Document { get; set; }
        public string Tag { get; set; }
        public string Login { get; set; }
    }
}