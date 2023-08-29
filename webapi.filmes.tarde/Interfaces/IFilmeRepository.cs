﻿using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
    public interface IFilmeRepository
    {
        //CRUD

        //tipoDeRetorno NomeMetodo(TipoParametro NomeParametro)
        /// <summary>
        /// Cadastrar um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto que será cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Retornar todos os filmes
        /// </summary>
        /// <returns>Uma Lista de filmes</returns>
        List<FilmeDomain> ListarTodos();


        /// <summary>
        /// Buscar um objeto através do seu id
        /// </summary>
        /// <param name="id">id do objeto que será buscado</param>
        /// <returns>Objeto que foi buscado</returns>
        FilmeDomain BuscarPorId(int id);

        /// <summary>
        /// Atualizar um filme existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="filme">Objeto com as novas informações</param>
        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualizar um filme existente passando o id pela URL da requisição
        /// </summary>
        /// <param name="id">Id do objeto a ser atualizado</param>
        /// <param name="genero">Objeto com as novas informações</param>
        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">Id </param>
        void Deletar(int id);
    }
}
