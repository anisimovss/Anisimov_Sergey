using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMVC.BlogDAL
{
    interface IDAL
    {
        bool AddDocument(Entities.Blog newBlog, string Login);
        bool AddComment(Entities.Comment newComment);
        bool AddUser(Entities.User newUser);
        bool CheckAddUser(string Login);
        bool LoginInSystem(string Login, string Password);
        IEnumerable<string> ShowBlogs();
    }
}
