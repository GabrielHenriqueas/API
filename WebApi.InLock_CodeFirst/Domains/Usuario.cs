using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.InLock_CodeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatório!")]        
        //[EmailAddress(ErrorMessage = "Email")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Senha obrigatório!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha de 6 a 60 caracteres!")]
        public string? Senha { get; set; }

        //referência tabela TipoUsuario
        [Required(ErrorMessage = "Tipo de Usuário obrigatório!")]

        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]

        public TiposUsuario? TipoUsuario { get; set;}
    }
}
