using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class GeneroRepository : IGeneroRepository
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

        /// <summary>
        /// Atualizar o gênero passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informações</param>
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateIdBody = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateUrl = "UPDATE Genero SET Nome = @Nome WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", genero.Nome);

                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    cmd.ExecuteNonQuery();
                }

            }
        }


        /// <summary>
        /// Buscar um gênero atravvés do seu id
        /// </summary>
        /// <param name="id">Id do gênero a ser buscado</param>
        /// <returns>Objeto Buscado</returns>
        public GeneroDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT IdGenero, Nome FROM Genero WHERE IdGenero = @IdGenero";

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    con.Open();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain generoBuscado = new GeneroDomain
                        {
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Nome = rdr["Nome"].ToString()
                        };

                        return generoBuscado;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Cadastrar um novo gênero
        /// </summary>
        /// <param name="novoGenero">Objero com as informações que serão cadastrados</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryInsert = "INSERT INTO Genero(Nome) VALUES(@Nome)";

                //Declara o SqlCommand passando a query que será executada e a conexão com o bd
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

                    //Abre a conexçao com o banco de dados
                    con.Open();

                    //Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletar o objeto selecionado do tipo gênero
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Deletar(int id)
        {
            //Declara a SqlConnetion passando a string conexão como pârametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a query que será executada
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @Id";

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

        /// <summary>
        /// Listar todos os objetos do tipo gênero
        /// </summary>
        /// <returns>Lista de objetos do tipo gênero</returns>
        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de gêneros onde será armazenados os dados os gêneros
            List<GeneroDomain> ListaGeneros = new List<GeneroDomain>();

            //Declara a SqlConnection passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Declara a instrução a ser executda
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

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
                        GeneroDomain genro = new GeneroDomain()
                        {
                            //Atribui a propriedade IdGenero o valor da primeira coluna da tabela
                            IdGenero = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade Nome o valor da Coluna Nome
                            Nome = rdr["Nome"].ToString()
                        };

                        //Adiciona o objeto criado dentro da lista
                        ListaGeneros.Add(genro);
                    }
                }
            }

            //Retorna a lista de gênero
            return ListaGeneros;
        }
    }
}
