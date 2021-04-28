using System;
using System.Collections.Generic;

#nullable disable

namespace HRoads_WebApi.Domains
{
    public partial class Class
    {
        public Class()
        {
            Personagens = new HashSet<Personagem>();
        }

        public int IdClasses { get; set; }
        public string NomeClasse { get; set; }

        public virtual ICollection<Personagem> Personagens { get; set; }
    }
}
