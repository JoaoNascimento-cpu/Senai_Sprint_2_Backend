using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class UsuarioDomain
    {
        //id do usuário cadastrado
        public int idUsuario { get; set; }

        //e-mail do usuário
        [Required(ErrorMessage = "você deverá escrever o e-mail do usuário")]
        public string email { get; set; }

        //senha do usuario
        [Required(ErrorMessage = "você deverá escrever a senha do usuário")]
        public string senha { get; set; }

        //id do tipo de usuario
        public int idTipoUsuario { get; set; }
    }
}
