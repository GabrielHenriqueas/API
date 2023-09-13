using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados, que recebe os seguintes parâmetros:
        /// Data Source : Nome do servidor do banco
        /// Initial Catolog : Nome do banco de dados
        /// Autenticação
        ///     -windowns : Integrated Security = True
        ///     -SqlServer : User Id = sa; Pwd = Senha
        /// </summary>
        private string StringConexao = "Data Source = NOTE06-S14; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";
        //private string StringConexao = "Data Source = NOTE06-S14; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        //===========================================================================================================================

        /// <summary>
        /// Atualizar o jogo passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="jogo">Objeto com as novas informações</param>
        public void AtualizarIdCorpo(JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Jogo SET Nome = @Nome, IdJogo = @IdJogo WHERE IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);

                    cmd.Parameters.AddWithValue("@IdJogo", jogo.IdJogo);

                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Atualizar jogo pela URL
        /// </summary>
        /// <param name="id">Id do jogo que irá ser atualizado</param>
        /// <param name="jogo">Objeto com as novas informações</param>
        public void AtualizarIdUrl(int id, JogoDomain jogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Jogo SET Nome = @Nome, IdEstudio = @IdEstudio WHERE IdJogo = @IdJogo";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", jogo.Nome);

                    cmd.Parameters.AddWithValue("@IdJogo", id);

                    cmd.Parameters.AddWithValue("@IdEstudio", jogo.IdEstudio);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Buscar um jogo através do seu id
        /// </summary>
        /// <param name="id">Id do jogo a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
        public JogoDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT Jogo.IdJogo, Jogo.Nome, Estudio.IdEstudio, Estudio.Nome FROM Jogo INNER JOIN Estudio on Estudio.IdEstudio = Jogo.IdEstudio WHERE @id = IdJogo";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            Nome = rdr["Nome"].ToString(),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo">Objeto com as informações que serão cadastrados</param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Jogo(Nome, IdEstudio) VALUES(@Nome, @IdEstudio)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);

                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    //Abre a conexçao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Deletar o objeto selecionado do tipo jogo
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @Id";

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
        /// Listar todos os objetos do tipo jogos
        /// </summary>
        /// <returns>Lista de objetos do tipo filme</returns>
        public List<JogoDomain> ListarTodos()
        {
            //Cria uma lista de filmes onde será armazenados os dados os filmes
            List<JogoDomain> ListaJogos = new List<JogoDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executda
                string querySelectAll = "SELECT Jogo.IdJogo, Jogo.Nome, Estudio.IdEstudio, Estudio.Nome FROM Jogo INNER JOIN Estudio on Estudio.IdEstudio = Jogo.IdEstudio";

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
                        JogoDomain jogo = new JogoDomain()
                        {
                            //Atribui a propriedade IdJogo o valor da primeira coluna da tabela
                            IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                            //Atribui a propriedade Nome o valor da Coluna Nome
                            Nome = rdr["Nome"].ToString(),

                            Estudio = new EstudioDomain()
                            {
                                IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),

                                Nome = rdr["Nome"].ToString()
                            }
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaJogos.Add(jogo);
                    }
                }
            }

            //Retorna a lista de filme
            return ListaJogos;
        }
    }
}
