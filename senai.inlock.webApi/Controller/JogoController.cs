using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controller
{
    /// <summary>
    /// Define que a rota de uma requisição será no seguinte formato
    /// dominio/api/nomeController
    /// exemplo: http://localhost:5000/api/Genero
    /// </summary>
    [Route("api/[controller]")]

    /// <summary>
    /// Define que é um controlador de API
    /// </summary>
    [ApiController]

    /// <summary>
    /// Define que é um controlador de API é JSON
    /// </summary>
    [Produces("application/json")]

    public class JogoController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IJogoRepository _jogoRepository { get; set; }


        /// <summary>
        /// Instância do objeto _filmeRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public JogoController()
        {
            _jogoRepository = new JogoRepository();
        }

        //===========================================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de listar os jogo
        /// </summary>
        /// <returns>Lista de jogos e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os jogos
                List<JogoDomain> ListaJogos = _jogoRepository.ListarTodos();

                //retorna o status code 200 ok e a lista de jogos no formato JSON
                return StatusCode(200, ListaJogos);
                //return Ok(ListaFilmes);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de cadastrar jogo
        /// </summary>
        /// <param name="novoJogo">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(JogoDomain novoJogo)
        {
            try
            {
                //Cria uma lista para receber os jogos
                _jogoRepository.Cadastrar(novoJogo);

                //retorna o status code
                //return Created("objeto criado", novoJogo);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Cria uma lista para receber os filmes
                _jogoRepository.Deletar(id);

                //retorna o status code
                //return Created("objeto criado", novoJogo);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

                if (jogoBuscado == null)
                {
                    return NotFound("O Jogo buscado não foi encontrado !");
                }

                return Ok(jogoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Atualizar jogo existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="jogo">Objeto jogo com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdCorpo(JogoDomain jogo)
        {
            try
            {
                //Cria um objeto jogoBuscado que irá receber o jogo buscado no banco de dados
                JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(jogo.IdJogo);

                //Verifica se algum jogo foi encontrado
                if (jogoBuscado != null)
                {
                    //Tenta atualizar o registro
                    try
                    {
                        //Faz a chamada para o método 
                        _jogoRepository.AtualizarIdCorpo(jogo);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Jogo não encontrado!");

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogoDomain UrlJogo)
        {
            try
            {
                //Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
                JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

                if (jogoBuscado != null)
                {
                    try
                    {
                        _jogoRepository.AtualizarIdUrl(id, UrlJogo);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Jogo não encongtrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
