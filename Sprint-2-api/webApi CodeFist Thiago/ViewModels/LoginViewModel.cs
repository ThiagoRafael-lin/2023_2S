using System.ComponentModel.DataAnnotations;

namespace webApi_CodeFist_Thiago.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email obrigatório !")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Senha obrigatório !")]

        public string Senha { get; set; }
    }
}
