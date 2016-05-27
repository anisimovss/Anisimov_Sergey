using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogMVC.Models
{
    public class UserPasswordViewModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(10,ErrorMessage ="Длина должна быть <=10")]
        public string User { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [StringLength(10, ErrorMessage = "Длина должна быть <=10")]
        public string Password { get; set; }
    }
}