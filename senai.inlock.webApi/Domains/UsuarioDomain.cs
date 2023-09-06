namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa Entidade(Tabela) Usuario;
    /// </summary>
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public int IdTipoUsuario { get; set; }

        public string? Email { get; set; }

        public string? Senha { get; set; }

        public TiposUsuarioDomain? TiposUsuario { get; set; }

    }
}
