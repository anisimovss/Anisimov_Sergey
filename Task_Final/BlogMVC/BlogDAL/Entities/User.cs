using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.BlogDAL.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}