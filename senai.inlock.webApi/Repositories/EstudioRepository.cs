using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class EstudioRepository : IEstudioRepository
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
        /// Atualizar o estudio passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="estudio">Objeto com as novas informações</param>
        public void AtualizarIdCorpo(EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Estudio SET Nome = @Nome WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Nome);

                    cmd.Parameters.AddWithValue("@IdEstudio", estudio.IdEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Atualizar o estudio pela URL
        /// </summary>
        /// <param name="id">Id do estudio a ser atualizado</param>
        /// <param name="estudio">Objeto com as novas informações</param>
        public void AtualizarIdUrl(int id, EstudioDomain estudio)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Estudio SET Nome = @Nome WHERE IdEstudio = @IdEstudio";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", estudio.Nome);

                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    cmd.ExecuteNonQuery();
                }

            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Buscar Estudio pelo ID
        /// </summary>
        /// <param name="id">Id do estudio a ser buscado</param>
        /// <returns></returns>
        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdEstudio, Nome FROM Estudio WHERE IdEstudio = @IdEstudio";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            IdEstudio = Convert.ToInt32(rdr["IdEstudio"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        return estudioBuscado;
                    }
                    return null;
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Cadastrar Estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto com as informações que serão cadastrados</param>
        public void Cadastrar(EstudioDomain novoEstudio)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Estudio(Nome) VALUES(@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

                    //Abre a conexçao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Deletar Estudio
        /// </summary>
        /// <param name="id">Id do objeto que irá ser deletado</param>
        public void Deletar(int id)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @Id";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    //Abre a conexão com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        //===========================================================================================================================

        
        public List<EstudioDomain> ListarTodos()
        {
            //Cria uma lista de gêneros onde será armazenados os dados os gêneros
            List<EstudioDomain> ListaEstudios = new List<EstudioDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executda
                string querySelectAll = "SELECT IdEstudio, Nome FROM Estudio";

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
                        EstudioDomain estudio = new EstudioDomain()
                        {
                            //Atribui a propriedade IdEstudio o valor da primeira coluna da tabela
                            IdEstudio = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Nome o valor da Coluna Nome
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaEstudios.Add(estudio);
                    }
                }
            }

            //Retorna a lista de gênero
            return ListaEstudios;
        }
    }
}
