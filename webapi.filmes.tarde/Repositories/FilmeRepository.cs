using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados, que recebe os seguintes parâmetros:
        /// Data Source : Nome do servidor do banco
        /// Initial Catolog : Nome do banco de dados
        /// Autenticação
        ///     -windowns : Integrated Security = True
        ///     -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE06-S14; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";
        //private string StringConexao = "Data Source = NOTE06-S14; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        //===========================================================================================================================

        /// <summary>
        /// Atualizar o filme passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto com as novas informações</param>
        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Buscar um filme através do seu id
        /// </summary>
        /// <param name="id">Id do filme a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
        public FilmeDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT Filme.IdFilme, Filme.Titulo, Genero.IdGenero, Genero.Nome FROM Filme INNER JOIN Genero on Genero.IdGenero = Filme.IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        FilmeDomain filmeBuscado = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        return filmeBuscado;
                    }
                    return null;
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objero com as informações que serão cadastrados</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(FilmeDomain novoFilme)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Filme(Titulo, IdGenero) VALUES(@Titulo, @IdGenero)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);

                    //Abre a conexçao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Deletar o objeto selecionado do tipo filme
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Deletar(int id)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @Id";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Listar todos os objetos do tipo filmes
        /// </summary>
        /// <returns>Lista de objetos do tipo filme</returns>
        public List<FilmeDomain> ListarTodos()
        {
            //Cria uma lista de filmes onde será armazenados os dados os filmes
            List<FilmeDomain> ListaFilmes = new List<FilmeDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executda
                string querySelectAll = "SELECT Filme.IdFilme, Filme.Titulo, Genero.IdGenero, Genero.Nome FROM Filme INNER JOIN Genero on Genero.IdGenero = Filme.IdGenero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer(ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto houver registros para serem lidos no rdr o laço se repetirá
                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            //Atribui a propriedade IdFilme o valor da primeira coluna da tabela
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                            //Atribui a propriedade Nome o valor da Coluna Nome
                            Titulo = rdr["Titulo"].ToString(),

                            Genero = new GeneroDomain()
                            {
                                IdGenero = Convert.ToInt32(rdr["IdGenero"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaFilmes.Add(filme);
                    }
                }
            }

            //Retorna a lista de filme
            return ListaFilmes;
        }
    }
}
