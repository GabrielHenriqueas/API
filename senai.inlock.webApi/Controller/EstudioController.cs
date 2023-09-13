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
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface
        /// </summary>
        private IEstudioRepository _estudioRepository { get; set; }


        /// <summary>
        /// Instância do objeto _estudioRepository para que haja referência aos mêtodos no repositório
        /// </summary>
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        //===========================================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de listar os estudios
        /// </summary>
        /// <returns>Lista de estudios e um status code</returns>
        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                //Cria uma lista para receber os gêneros
                List<EstudioDomain> ListaEstudios = _estudioRepository.ListarTodos();

                //retorna o status code 200 ok e a lista de estudios no formato JSON
                return StatusCode(200, ListaEstudios);
                //return Ok(ListaEstudios);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem de erro
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Endpoint que acessa o método de cadastrar estudio
        /// </summary>
        /// <param name="novoEstudio">Objeto recebido na requisição</param>
        /// <returns>Status Code</returns>
        [HttpPost]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                //Cria uma lista para receber os estudios
                _estudioRepository.Cadastrar(novoEstudio);

                //retorna o status code
                //return Created("objeto criado", novoEstudio);
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
                //Cria uma lista para receber os gêneros
                _estudioRepository.Deletar(id);

                //retorna o status code
                //return Created("objeto criado", novoEstudio);
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
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado == null)
                {
                    return NotFound("O Estudio buscado não foi encontrado !");
                }

                return Ok(estudioBuscado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Atualizar estudio existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto estudio com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdCorpo(EstudioDomain estudio)
        {
            try
            {
                //Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(estudio.IdEstudio);

                //Verifica se algum estudio foi encontrado
                if (estudioBuscado != null)
                {
                    //Tenta atualizar o registro
                    try
                    {
                        //Faz a chamada para o método 
                        _estudioRepository.AtualizarIdCorpo(estudio);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Estudio não encontrado!");

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        //===========================================================================================================================

        /// <summary>
        /// Atualizar Estudio pela URL
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UrlEstudio"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain UrlEstudio)
        {
            try
            {
                //Cria um objeto estudioBuscado que irá receber o estudio buscado no banco de dados
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado != null)
                {
                    try
                    {
                        _estudioRepository.AtualizarIdUrl(id, UrlEstudio);

                        return NoContent();
                    }
                    catch (Exception erro)
                    {

                        return BadRequest(erro.Message);
                    }
                }
                return NotFound("Estudio não encontrado!");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
