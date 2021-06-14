using System.ComponentModel.DataAnnotations;

namespace WebUI.Models.Account
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Введите логин")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль ")]
        public string Password { get; set; }
    }
}
