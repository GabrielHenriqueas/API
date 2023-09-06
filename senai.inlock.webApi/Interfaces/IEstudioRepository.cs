using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// CADASTRAR TODOS OS ESTUDIOS
        /// </summary>
        /// <param name="novoEstudio">objeto que irá ser cadastarado</param>
        void Cadastrar(EstudioDomain novoEstudio);

        /********************************************************************************************/

        /// <summary>
        /// LISTAR TODOS OS ESTUDIOS
        /// </summary>
        /// <returns>uma lista de ESTUDIOS</returns>
        List<EstudioDomain> ListarTodos();

        /********************************************************************************************/

        /// <summary>
        /// BUSCAR UM ESTUDIO PELO ID
        /// </summary>
        /// <param name="id">id do objeto buscado</param>
        /// <returns>objeto que foi buscado</returns>
        EstudioDomain BuscarPorId(int id);

        /********************************************************************************************/

        /// <summary>
        /// ATUALIZAR O ESTUDIO PELO CORPO
        /// </summary>
        /// <param name="estudio">objeto com as novas informações</param>
        void AtualizarIdCorpo(EstudioDomain estudio);

        /********************************************************************************************/

        /// <summary>
        /// ATUALIZAR O ESTUDIO PELA URL
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <param name="estudio">objeto com as novas informações</param>
        void AtualizarIdUrl(int id, EstudioDomain estudio);

        /********************************************************************************************/

        /// <summary>
        /// DELETAR O ESTUDIO PELO ID
        /// </summary>
        /// <param name="id">id do objeto que irá ser deletado</param>
        void Deletar(int id);

        /********************************************************************************************/
    }
}
