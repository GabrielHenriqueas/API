using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// MÉTODO QUE BUSCA UM USUÁRIO POR EMAIL E SENHA
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns></returns>
        UsuarioDomain Login(string email, string senha);
    }
}
