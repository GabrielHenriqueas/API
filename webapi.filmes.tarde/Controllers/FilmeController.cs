using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

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

    public class FilmeController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IFilmeRepository _filmeRepository { get; set; }


        /// <summary>
        /// Instância do objeto _filmeRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public FilmeController()
        {
            _filmeRepository = new FilmeRepository();
        }

        //===========================================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de listar os filme
        /// </summary>
        /// <returns>Lista de filmes e um status code</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os filmes
                List<FilmeDomain> ListaFilmes = _filmeRepository.ListarTodos();

                //retorna o status code 200 ok e a lista de filmes no formato JSON
                return StatusCode(200, ListaFilmes);
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
        /// Endpoint que acessa o método de cadastrar filme
        /// </summary>
        /// <param name="novoFilme">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                //Cria uma lista para receber os filmes
                _filmeRepository.Cadastrar(novoFilme);

                //retorna o status code
                //return Created("objeto criado", novoFilme);
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
                _filmeRepository.Deletar(id);

                //retorna o status code
                //return Created("objeto criado", novoFilme);
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
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado == null)
                {
                    return NotFound("O Filme buscado não foi encontrado !");
                }

                return Ok(filmeBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Atualizar filme existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto filme com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdCorpo(FilmeDomain filme)
        {
            try
            {
                //Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);

                //Verifica se algum filme foi encontrado
                if (filmeBuscado != null)
                {
                    //Tenta atualizar o registro
                    try
                    {
                        //Faz a chamada para o método 
                        _filmeRepository.AtualizarIdCorpo(filme);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Filme não encontrado!");

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FilmeDomain UrlFilme)
        {
            try
            {
                //Cria um objeto filmeBuscado que irá receber o filme buscado no banco de dados
                FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

                if (filmeBuscado != null)
                {
                    try
                    {
                        _filmeRepository.AtualizarIdUrl(id, UrlFilme);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Filme não encongtrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
