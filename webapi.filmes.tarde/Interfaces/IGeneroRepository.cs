using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    /// <summary>
    /// Interface resposnsável pelo repositório GenenroRepository
    /// Define os métodos que serão implementados pelo repositório
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD

        //tipoDeRetorno NomeMetodo(TipoParametro NomeParametro)
        /// <summary>
        /// Cadastrar um novo Gênero
        /// </summary>
        /// <param name="novoGenero">Objeto que será cadastrado</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Retornar todos os genêro
        /// </summary>
        /// <returns>Uma Lista de genêros</returns>
        List<GeneroDomain> ListarTodos();


        /// <summary>
        /// Buscar um objeto através do seu id
        /// </summary>
        /// <param name="id">id do objeto que será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Atualizar um gênenero existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualizar um gênero existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id </param>
        void Deletar(int id);
    }
}
