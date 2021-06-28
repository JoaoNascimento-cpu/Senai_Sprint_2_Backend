using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sp_Medical_Group.WebAPI.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Escreva o email válido para o cadastro")]
        public string Email { get; set; }
        [Required(ErrorMessage = "É necessário o uso de senhas para o cadastro")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Sua senha deverá ter de 3 a 10 caracteres")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
