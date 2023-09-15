using System.ComponentModel.DataAnnotations;

namespace WebApi.InLock_CodeFirst.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório!")]
        public string? Senha { get; set; }
    }
}
