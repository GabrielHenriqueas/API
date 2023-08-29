using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que represenyta a entidade(tabela) Filme
    /// </summary>
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "O tíitulo do filme é obrigatório")]

        public int IdGenero { get; set; }


        //Referencia para a clase Genero
        public GeneroDomain? Genero { get; set; }
    }
}
