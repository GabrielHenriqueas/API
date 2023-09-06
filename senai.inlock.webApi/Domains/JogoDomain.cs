namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a Entidade(Tabela) Jogo;
    /// </summary>
    public class JogoDomain
    {
        public int IdJogo { get; set; }

        public int IdEstudio { get; set; }

        public string? Nome { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataLancamento { get; set; }

        public int Valor { get; set; }

        public EstudioDomain? Estudio { get; set; }

    }
}
