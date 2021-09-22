using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IMarcaRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<MarcaDomain> ListarTodos();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMarca"></param>
        /// <returns></returns>
        MarcaDomain BuscarId(int idMarca);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMarca"></param>
        void Cadastrar(MarcaDomain idMarca);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMarca"></param>
        /// <param name="marcaAtualizada"></param>
        void AtualizarIdUrl(int idMarca, MarcaDomain marcaAtualizada);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="marcaAtualizada"></param>
        void AtualizarIdCorpo(MarcaDomain marcaAtualizada);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMarca"></param>
        void Deletar(int idMarca);
    }
}
