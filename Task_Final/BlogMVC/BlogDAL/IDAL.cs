using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMVC.BlogDAL
{
    interface IDAL
    {
        bool AddDocument(Entities.Blog newBlog, string Login); //Добавление 
        bool AddComment(Entities.Comment newComment, string Login); //Добавление 
        bool AddUser(Entities.User newUser); //Добавление
        bool CheckAddUser(string Login); //Проверка на добавление
        bool LoginInSystem(string Login, string Password); //Вход, проверка
        IEnumerable<string> ShowBlogs(); //Показать все имена
        IEnumerable<Entities.Blog> GetBlogByName(string Login); //Вывести содержимое определенного блога
        int FindId(string Login); //Поиск id по login 
        IEnumerable<Entities.Comment> ShowComment(string BlogID); // Показать комментарии
        IEnumerable<Entities.Blog> GetBlogByTag(string Tag);  //Поиск блога по тегу
        IEnumerable<Entities.Blog> GetBlogByText(string Text);  //Поиск блога по тексту
        bool DeleteUser(string Name);  //удаление пользователя
        bool DeleteComment(int CommentID);  //удаление комментария
        bool DeleteDocument(int BlogID);  //удаление статьи 
        string GetLoginByID(int UserID);  //Найти Login по UserID
        string GetLoginByBlogID(int BlogID); //Найти Login по BlogID
    }
}
