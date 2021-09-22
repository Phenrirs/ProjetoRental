using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade de empresas cadastradas!
    /// </summary>
    public class EmpresaDomain
    {
        public int idEmpresa { get; set; }
        public string nomeEmpresa { get; set; }
        public string Endereco { get; set; }
    }
}
