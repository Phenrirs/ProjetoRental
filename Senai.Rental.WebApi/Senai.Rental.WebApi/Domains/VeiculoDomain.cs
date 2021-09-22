using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Essa classe representa a tabela/Entidade intermediaria que tem como intuito identificar os dados gerais dos veiculos! 
    /// </summary>
    public class VeiculoDomain
    {
        public int idVeiculo { get; set; }
        public int idModelo { get; set; }
        public int idEmpresa { get; set; }
        public string Placa { get; set; }
        public ModeloDomain Modelo { get; set; }
        public EmpresaDomain Empresa { get; set; }
    }
}
