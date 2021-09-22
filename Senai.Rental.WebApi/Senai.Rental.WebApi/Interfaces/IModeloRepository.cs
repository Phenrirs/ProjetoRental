using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IModeloRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<ModeloDomain> ListarTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idModelo"></param>
        /// <returns></returns>
        ModeloDomain BuscarId(int idModelo);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoModelo"></param>
        void Cadastrar(int novoModelo);

        /// <summary>
        /// /
        /// </summary>
        /// <param name="idModelo"></param>
        /// <param name="modeloAtualizado"></param>
        void AtualizarIdUrl(int idModelo, ModeloDomain modeloAtualizado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modeloAtualizado"></param>
        void AtualizarIdCorpo(ModeloDomain modeloAtualizado);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idModelo"></param>
        void Deletar(int idModelo);


    }
}
