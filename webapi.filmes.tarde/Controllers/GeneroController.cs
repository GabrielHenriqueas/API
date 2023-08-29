using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace webapi.filmes.tarde.Controllers
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

    
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }


        /// <summary>
        /// Instância do objeto _generoRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public GeneroController()
        {
            _generoRepository= new GeneroRepository();
        }

        /// <summary>
        /// Endpoint que acessa o método de listar os gêneros
        /// </summary>
        /// <returns>Lista de gêneros e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os gêneros
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();

                //retorna o status code 200 ok e a lista de gêneros no formato JSON
                return StatusCode(200, ListaGeneros);
                //return Ok(ListaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que acessa o método de cadastrar gênero
        /// </summary>
        /// <param name="novoGenero">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(GeneroDomain novoGenero)
        {
            try
            {
                //Cria uma lista para receber os gêneros
                _generoRepository.Cadastrar(novoGenero);

                //retorna o status code
                //return Created("objeto criado", novoGenero);
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //Cria uma lista para receber os gêneros
                _generoRepository.Deletar(id);

                //retorna o status code
                //return Created("objeto criado", novoGenero);
                return StatusCode(204);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado == null)
                {
                    return NotFound("O Gênero buscado não foi encontrado !");
                }

                return Ok(generoBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualizar gênero existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdCorpo(GeneroDomain genero)
        {
            try
            {
                //Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(genero.IdGenero);

                //Verifica se algum gênero foi encontrado
                if (generoBuscado != null)
                {
                    //Tenta atualizar o registro
                    try
                    {
                        //Faz a chamada para o método 
                        _generoRepository.AtualizarIdCorpo(genero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Gênero não encontrado!");
           
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, GeneroDomain UrlGenero)
        {
            try
            {
                //Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
                GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

                if (generoBuscado != null)
                {
                    try
                    {
                        _generoRepository.AtualizarIdUrl(id, UrlGenero);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Gênero não encongtrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
