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

        public bool AddComment(Comment newComment)
        {
            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("insert into BlogDB.Comments (UserID, Comment, BlogID) values (@userid ,@comment, @blogid)",connection);
                command.Parameters.AddWithValue("@userid", newComment.UserID);
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
                var command = new SqlCommand("select * from BlogDB.Users where Login=@login", connection);
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
                var command = new SqlCommand("select * from BlogDB.Users where Login=@login and Password=@password", connection);
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
                var command = new SqlCommand("select distinct(Users.UserID) from BlogDB.Blogs " +
                    "join BlogDB.Users on Users.UserID = Blogs.UserID where Login=@login", connection);
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

        public IEnumerable<Blog> GetBlogByName(string Login)
        {
            var result = new List<Blog>();

            using (var connection = new SqlConnection(connectionsString))
            {
                var command = new SqlCommand("select Document, Login, Tag from BlogDB.Blogs " + 
                    "join BlogDB.Users on Users.UserID = Blogs.UserID where Login=@login", connection);
                command.Parameters.AddWithValue("@login", Login);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var blog = new Blog();
                        blog.Document = reader.GetString(0);
                        blog.Login = reader.GetString(1);
                        blog.Tag = reader.GetString(2);
                        result.Add(blog);
                    }
                }
            }
            return result;
        }

    }
}