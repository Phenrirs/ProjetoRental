using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;

namespace Senai.Rental.WebApi.Interfaces
{
    interface IEmpresaRepository
    {
        /// <summary>
        /// Retorna todas as empresas e filiais!
        /// </summary>
        /// <returns></returns>
        List<EmpresaDomain> ListarTodos();

        /// <summary>
        /// Retorna através do id a empresa buscada!
        /// </summary>
        /// <param name="idEmpresa"></param>
        /// <returns>Um objeto do tipo EmpresaDomain que foi buscado</returns>
        EmpresaDomain BuscarPorId(int idEmpresa);

        /// <summary>
        /// Responsável por cadastrar uma nova empresa!
        /// </summary>
        /// <param name="novaEmpresa">Objeto novaEmpresa com os dados que serão cadastrados</param>
        void Cadastrar(EmpresaDomain novaEmpresa);

        /// <summary>
        /// Responsável por atualizar os dados da empresa pelo corpo da requisição! ou seja, sem alterar o id!
        /// </summary>
        /// <param name="empresaAtualizada">Objeto empresaAtualizada com os novos dados!</param>
        void AtualizarIdCorpo(EmpresaDomain empresaAtualizada);

        /// <summary>
        /// Responsável por atualizar os dados da empresa através do id!
        /// </summary>
        /// <param name="idEmpresa">Objeto que indica a busca pelo id!</param>
        /// <param name="empresaAtualizada">Objeto empresaAtualizada com os novos dados!</param>
        void AtualizarIdUrl(int idEmpresa, EmpresaDomain empresaAtualizada);

        /// <summary>
        /// Responsável por deletar os dados das empresas cadastradas!
        /// </summary>
        /// <param name="idEmpresa">Objeto que identifica o id que será deletado!</param>
        void Deletar(int idEmpresa);
    }
}
