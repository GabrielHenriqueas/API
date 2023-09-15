using WebApi.InLock_CodeFirst.Domains;

namespace WebApi.InLock_CodeFirst.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);

        void Cadastrar(Usuario usuario);
    }
}
