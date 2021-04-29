using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples_WebApi.Domains
{
    /// <summary>
    /// Referencia sobre os funcionarios e eseus dados
    /// </summary>
    public class FuncionarioDomain
    {
        public int idFuncionario { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
    }
}
