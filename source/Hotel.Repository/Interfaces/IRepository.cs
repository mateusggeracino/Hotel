using System;
using System.Collections.Generic;

namespace Hotel.Repository.Interfaces
{
    /// <summary>
    /// Contrato genérico, responsável por obrigar a implementação de seus métodos aos repositórios.
    /// </summary>
    /// <typeparam name="T">Entidade genérica</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Responsável por inserir no banco de dados/lista genérica
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T Insert(T obj);

        /// <summary>
        /// Responsável por obter objeto cadastrado através do id.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Responsável por obter todos os itens cadastrados.
        /// </summary>
        /// <returns></returns>
        List<T> GetAll();

        /// <summary>
        /// Responsável por atualizar as informações de um objeto.
        /// </summary>
        /// <param name="obj"></param>
        void Update(T obj);

        /// <summary>
        /// Responsável por remover um objeto da lista de cadastrados
        /// </summary>
        /// <param name="obj"></param>
        void Remove(T obj);

        /// <summary>
        /// Método responsável obter informações com base nas propriedades da entidade genérica
        /// </summary>
        /// <param name="predicate">Garante que o parâmetro seja uma expressão lambda</param>
        /// <returns></returns>
        List<T> Find(Func<T, bool> predicate);
    }
}
