using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    public class AluguelDomain
    {

        /// <summary>
        /// Essa classe representa a entidade de aluguel que tem o intuito de demonstrar os dados referentes a dias, horas, preço e veiculos alugados!
        /// </summary>
        public int idAluguel { get; set; }
        public int idVeiculo { get; set; }
        public int idCliente { get; set; }
        public string Preco { get; set; }
        public string Inicio { get; set; }
        public string Fim { get; set; }
        public VeiculoDomain Veiculo { get; set; }
        public ClienteDomain Cliente { get; set; }
    }
}
