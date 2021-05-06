using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade/tabela Gêneros
    /// </summary>
    public class GeneroDomain
    {
        public int idGenero { get; set; }

        [Required(ErrorMessage = "È necessário o preenchimento do nome do gênero no campo entre as chaves!")]
        public string nome { get; set; }

    }
}
