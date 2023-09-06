using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// CADASTRAR TODOS OS JOGOS
        /// </summary>
        /// <param name="novoJogo">objeto que irá ser cadastarado</param>
        void Cadastrar(JogoDomain novoJogo);

        /********************************************************************************************/

        /// <summary>
        /// LISTAR TODOS OS JOGOS
        /// </summary>
        /// <returns>uma lista de JOGOS</returns>
        List<JogoDomain> ListarTodos();

        /********************************************************************************************/

        /// <summary>
        /// BUSCAR UM JOGO PELO ID
        /// </summary>
        /// <param name="id">id do objeto buscado</param>
        /// <returns>objeto que foi buscado</returns>
        JogoDomain BuscarPorId(int id);

        /********************************************************************************************/

        /// <summary>
        /// ATUALIZAR O JOGO PELO CORPO
        /// </summary>
        /// <param name="jogo">objeto com as novas informações</param>
        void AtualizarIdCorpo(JogoDomain jogo);

        /********************************************************************************************/

        /// <summary>
        /// ATUALIZAR O JOGO PELA URL
        /// </summary>
        /// <param name="id">id do objeto a ser atualizado</param>
        /// <param name="jogo">objeto com as novas informações</param>
        void AtualizarIdUrl(int id, JogoDomain jogo);

        /********************************************************************************************/

        /// <summary>
        /// DELETAR O JOGO PELO ID
        /// </summary>
        /// <param name="id">id do objeto que irá ser deletado</param>
        void Deletar(int id);

        /********************************************************************************************/
    }
}
