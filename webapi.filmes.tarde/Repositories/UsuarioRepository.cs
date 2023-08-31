using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
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
        
        public UsuarioDomain Login(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT IdUsuari, Email, Permissao FROM Usuario WHERE Email = @Email AND Senha = @Senha";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    cmd.Parameters.AddWithValue("@Senha", senha);

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),

                            Email = rdr["Email"].ToString(),

                            Permissao = rdr["Permissao"].ToString(),
                        };

                        return usuario;
                    }
                    return null;
                }
            }
        }
    }
}
