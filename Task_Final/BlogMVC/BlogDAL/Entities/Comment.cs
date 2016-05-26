using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMVC.BlogDAL.Entities
{
    public class Comment
    {
        public int CommentID { get; set; }
        public int UserID { get; set; }
        public string CommentText { get; set; }
        public int BlogID { get; set; }
        public string Login { get; set; }
    }
}