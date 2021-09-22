using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Essa classe representa a entidade de marcas cadastradas
    /// </summary>
    public class MarcaDomain
    {
        public int idMarca { get; set; }
        public string nomenclatura { get; set; }
    }
}
