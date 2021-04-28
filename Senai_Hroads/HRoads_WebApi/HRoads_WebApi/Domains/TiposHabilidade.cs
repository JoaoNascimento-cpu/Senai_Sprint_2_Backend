using System;
using System.Collections.Generic;

#nullable disable

namespace HRoads_WebApi.Domains
{
    public partial class TiposHabilidade
    {
        public TiposHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTiposHabilidades { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
