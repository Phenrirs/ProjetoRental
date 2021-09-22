using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IClienteRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ClienteDomain> ListarTodos();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        ClienteDomain BuscarPorId(int idCliente);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoCliente"></param>
        void Cadastrar(ClienteDomain novoCliente);
        
        /// <summary>
        /// /
        /// </summary>
        /// <param name="clienteAtualizado"></param>
        void AtualizarIdCorpo(ClienteDomain clienteAtualizado);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="clienteAtualizado"></param>
        void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado);
        
        /// <summary>
        /// /
        /// </summary>
        /// <param name="idCliente"></param>
        void Deletar(int idCliente);

    }
}
