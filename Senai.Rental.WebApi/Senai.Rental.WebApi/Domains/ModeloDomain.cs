using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Essa classe representa a entidade de modelos de carros cadastrados!
    /// </summary>
    public class ModeloDomain
    {
        public int idModelo { get; set; }
        public int idMarca { get; set; }
        public string nomeModelo { get; set; }
        public MarcaDomain Marca { get; set; }
    }
}
