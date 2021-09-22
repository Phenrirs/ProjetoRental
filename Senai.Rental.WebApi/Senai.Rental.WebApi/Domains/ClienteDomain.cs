using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Essa classe representa os clientes cadastrados
    /// </summary>
    public class ClienteDomain
    {
        public int idCliente { get; set; }
        public string nomeCliente { get; set; }
        public string sobreNome { get; set; }
    }
}
