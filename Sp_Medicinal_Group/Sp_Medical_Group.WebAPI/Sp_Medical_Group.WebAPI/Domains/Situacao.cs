using System;
using System.Collections.Generic;

#nullable disable

namespace Sp_Medical_Group.WebAPI.Domains
{
    public partial class Situacao
    {
        public Situacao()
        {
            Consulta = new HashSet<Consultum>();
        }

        public int IdSituacao { get; set; }
        public string SituacaoNome { get; set; }

        public virtual ICollection<Consultum> Consulta { get; set; }
    }
}
