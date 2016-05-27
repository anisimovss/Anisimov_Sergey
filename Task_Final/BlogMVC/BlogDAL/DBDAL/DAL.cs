using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlogMVC.BlogDAL.Entities;
using System.Data.SqlClient;

namespace BlogMVC.BlogDAL.DBDAL
{
    public class DAL : IDAL
    {
        private string connectionsString = @"Data Source = (localdb)\ProjectsV12; Database = BlogDB; Integrated Security = True";

        public bool AddComment(Comment newComment, string Login)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("insert into BlogDB.Comments (UserID, Comment, BlogID) values (@userid ,@comment, @blogid)",connection);
                command.Parameters.AddWithValue("@userid", FindId(Login));
                command.Parameters.AddWithValue("@comment", newComment.CommentText);
                command.Parameters.AddWithValue("@blogid", newComment.BlogID);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
        
        public bool AddDocument(Blog newBlog, string Login)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("insert into BlogDB.Blogs (UserID, Document, Tag) values (@userid, @document, @tag)", connection);
                command.Parameters.AddWithValue("@userid", FindId(Login));
                command.Parameters.AddWithValue("@document", newBlog.Document);
                command.Parameters.AddWithValue("@tag", newBlog.Tag);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool AddUser(User newUser)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("insert into BlogDB.Users (Login, Password) values (@login,@password)",connection);
                command.Parameters.AddWithValue("@login", newUser.Login);
                command.Parameters.AddWithValue("@password", newUser.Password);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }            
        }

        public bool CheckAddUser(string Login)
        {
            bool result = true;
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select UserID, Login, Password from BlogDB.Users where Login=@login", connection);
                command.Parameters.AddWithValue("@login", Login);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = false;
                    }
                }
            }
            return result;
        }

        public bool LoginInSystem(string Login, string Password)
        {
            bool result = false;
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select UserID, Login, Password from BlogDB.Users where Login=@login and Password=@password", connection);
                command.Parameters.AddWithValue("@login", Login);
                command.Parameters.AddWithValue("@password", Password);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = true;
                    }
                }
            }
            return result;
        }

        public IEnumerable<string> ShowBlogs()
        {
            var result = new List<string>();

            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select Login from BlogDB.Users", connection);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                }
            }
            return result;
        }

        public int FindId(string Login)
        {
            int result = 0;
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select Users.UserID from BlogDB.Users where Login=@login ", connection);
                command.Parameters.AddWithValue("@login", Login);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }
                }
            }
            return result;
        }

        public string GetLoginByID(int UserID)
        {
            string result = "";
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select Login from BlogDB.Users where UserID=@userid", connection);
                command.Parameters.AddWithValue("@userid", UserID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader.GetString(0);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Blog> GetBlogByName(string Login)
        {
            var result = new List<Blog>();

            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select BlogID, Document, Login, Tag from BlogDB.Blogs " + 
                    "join BlogDB.Users on Users.UserID = Blogs.UserID where Login=@login", connection);
                command.Parameters.AddWithValue("@login", Login);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var blog = new Blog();
                        blog.BlogID = reader.GetInt32(0);
                        blog.Document = reader.GetString(1);
                        blog.Login = reader.GetString(2);
                        blog.Tag = reader.GetString(3);
                        result.Add(blog);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Comment> ShowComment(string BlogID)
        {
            var result = new List<Comment>();
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select UserID, Comment, CommentID from BlogDB.Comments where BlogID=@blogid", connection);
                command.Parameters.AddWithValue("@blogid", BlogID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var comment = new Comment();
                        comment.Login = GetLoginByID(reader.GetInt32(0));
                        comment.CommentText = reader.GetString(1);
                        comment.CommentID = reader.GetInt32(2);
                        result.Add(comment);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Blog> GetBlogByTag(string Tag)
        {
            var result = new List<Blog>();
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select BlogID, UserID, Document, Tag from BlogDB.Blogs where Tag=@tag", connection);
                command.Parameters.AddWithValue("@tag", Tag);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var blog = new Blog();
                        blog.BlogID = reader.GetInt32(0);
                        blog.Login = GetLoginByID(reader.GetInt32(1));
                        blog.Document = reader.GetString(2);
                        blog.Tag = reader.GetString(3);
                        result.Add(blog);
                    }
                }
            }
            return result;
        }

        public IEnumerable<Blog> GetBlogByText(string Text)
        {
            var result = new List<Blog>();
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select BlogID, UserID, Document, Tag from BlogDB.Blogs where Document like @text", connection);
                command.Parameters.AddWithValue("@text", "%"+Text+"%");

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var blog = new Blog();
                        blog.BlogID = reader.GetInt32(0);
                        blog.Login = GetLoginByID(reader.GetInt32(1));
                        blog.Document = reader.GetString(2);
                        blog.Tag = reader.GetString(3);
                        result.Add(blog);
                    }
                }
            }
            return result;
        }

        public bool DeleteUser(string Name)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("delete from BlogDB.Users where Login=@name", connection);
                command.Parameters.AddWithValue("@name", Name.Replace(" ",""));
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public int FindBlogIdByCommentID(int CommentID)
        {
            int result = 0;
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select BlogID from BlogDB.Comments where CommentID=@commentid ", connection);
                command.Parameters.AddWithValue("@commentid", CommentID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = reader.GetInt32(0);
                    }
                }
            }
            return result;
        }

        public bool DeleteComment(int CommentID)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("delete from BlogDB.Comments where CommentID=@commentid", connection);
                command.Parameters.AddWithValue("@commentid", CommentID);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public bool DeleteDocument(int BlogID)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("delete from BlogDB.Blogs where BlogID=@blogid", connection);
                command.Parameters.AddWithValue("@blogid", BlogID);
                connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }

        public string GetLoginByBlogID(int BlogID)
        {
            int id = 0;
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select UserID from BlogDB.Blogs where BlogID=@blogid ", connection);
                command.Parameters.AddWithValue("@blogid", BlogID);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                }
            }
            return GetLoginByID(id);
        }

    }
}