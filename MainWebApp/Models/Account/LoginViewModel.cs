using System.ComponentModel.DataAnnotations;

namespace MainWebApp.Models.Account
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль ")]
        public string Password { get; set; }

        public string Role { get; set; }
    }
}
