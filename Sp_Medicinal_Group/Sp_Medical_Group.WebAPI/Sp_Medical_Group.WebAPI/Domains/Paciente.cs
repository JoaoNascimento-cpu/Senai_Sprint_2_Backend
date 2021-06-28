using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sp_Medical_Group.WebAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        [Required(ErrorMessage = "Escreva um nome para realizar o cadastro")]
        public string NomePaciente { get; set; }
        [Required(ErrorMessage = "Escreva seu rg para se cadastrar")]
        [StringLength(12, ErrorMessage = "informe um rg válido")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Escreva seu CPF para se cadastrar")]
        [StringLength(14, ErrorMessage = "informe um cpf válido")]
        public string Cpf { get; set; }
        [StringLength(9, ErrorMessage = "informe um número de telefone válido")]
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
