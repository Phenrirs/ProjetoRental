using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IVeiculoRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<VeiculoDomain> ListarTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <returns></returns>
        VeiculoDomain BuscarId(int idVeiculo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoVeiculo"></param>
        void Cadastrar(VeiculoDomain novoVeiculo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <param name="veiculoAtualizado"></param>
        void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="veiculoAtualizado"></param>
        void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado);

        void Deletar(int idVeiculo);
       
    }
}
