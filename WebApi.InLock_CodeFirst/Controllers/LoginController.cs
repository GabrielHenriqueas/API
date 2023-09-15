using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebApi.InLock_CodeFirst.Domains;
using WebApi.InLock_CodeFirst.Interfaces;
using WebApi.InLock_CodeFirst.Repositories;
using WebApi.InLock_CodeFirst.ViewModels;

namespace WebApi.InLock_CodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email, usuario.Senha!);

                if (usuarioBuscado == null)
                {
                    return StatusCode(401, "Email ou senha inválidos!");
                }

                return Ok(usuarioBuscado);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
