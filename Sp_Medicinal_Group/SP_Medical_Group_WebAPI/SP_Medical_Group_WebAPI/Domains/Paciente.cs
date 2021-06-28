using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SP_Medical_Group_WebAPI.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }

        public string NomePaciente { get; set; }

        [Required(ErrorMessage ="Escreva seu rg para se cadastrar")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Escreva seu CPF para se cadastrar")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Escreva seu número de telefone para se cadastrar")]
        public string Telefone { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
