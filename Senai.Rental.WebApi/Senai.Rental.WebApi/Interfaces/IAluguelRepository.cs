using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IAluguelRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<AluguelDomain> ListarTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAluguel"></param>
        /// <returns></returns>
        AluguelDomain BuscarId(int idAluguel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoAluguel"></param>
        void Cadastrar(AluguelDomain novoAluguel);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAluguel"></param>
        /// <param name="aluguelAtualizado"></param>
        void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="aluguelAtualizado"></param>
        void AtualizaridCorpo(AluguelDomain aluguelAtualizado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAluguel"></param>
        void Deletar(int idAluguel);
    }
}
