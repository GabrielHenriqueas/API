using WebApi.InLock_CodeFirst.Contexts;
using WebApi.InLock_CodeFirst.Domains;
using WebApi.InLock_CodeFirst.Interfaces;
using WebApi.InLock_CodeFirst.Utils;

namespace WebApi.InLock_CodeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly InLockContext ctx;

        public UsuarioRepository() 
        {
            ctx = new InLockContext();
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GeraHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(x => x.Email == email);

                if (usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere) 
                    {
                        return usuarioBuscado;
                    }                    
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
