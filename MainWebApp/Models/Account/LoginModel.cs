using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainWebApp.Models.Account
{
    public class LoginModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль ")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
