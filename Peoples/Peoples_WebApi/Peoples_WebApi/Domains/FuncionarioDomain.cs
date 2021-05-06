using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "É nescessário o preenchimento do nome do funcionário")]
        public string nome { get; set; }
        [Required(ErrorMessage = "É nescessário o preenchimento do Sobrenome do Funcionário")]
        public string sobrenome { get; set; }
        [Required(ErrorMessage = "Envie a data de aniversário do funcionário")]
        [DataType(DataType.Date)]
        public DateTime dataNascimento { get; set; }
    }
}
