using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.InLock_CodeFirst.Domains
{
    [Table("Estudio")]
    public class Estudio
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome obrigatório!")]
        public string? Nome{ get; set; }

        //referência a lista de jogos
        public List<Jogo>? Jogo { get; set; }
    }
}
