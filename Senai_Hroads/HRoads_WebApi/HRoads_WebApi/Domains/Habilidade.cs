using System;
using System.Collections.Generic;

#nullable disable

namespace HRoads_WebApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public string NomeHabilidade { get; set; }
        public int? IdTiposHabilidades { get; set; }

        public virtual TiposHabilidade IdTiposHabilidadesNavigation { get; set; }
    }
}
