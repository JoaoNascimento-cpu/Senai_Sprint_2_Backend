using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade (tabela) Usuarios no BD
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        //Define que o campo é obrigatório, se não preenchido aparecerá a mensagem de erro 'errorMessage'
        [Required(ErrorMessage = "É nescessário o preenchimento do email do usuário")]
        public string email { get; set; }

        //Define que o campo é obrigatório, com no mínimo 6 a 15 caracteres se não preenchido aparecerá a mensagem de erro 'errorMessage'
        [Required(ErrorMessage = "informe a senha")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Este campo deverá ter no minimo de 6 a 15 caracteres")]
        public string senha { get; set; }
        public string permissao { get; set; }
    }
}
