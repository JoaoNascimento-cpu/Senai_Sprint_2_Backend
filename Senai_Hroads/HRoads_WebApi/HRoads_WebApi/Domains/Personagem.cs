using System;
using System.Collections.Generic;

#nullable disable

namespace HRoads_WebApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; }
        public int? IdClasse { get; set; }
        public int? PvMaximo { get; set; }
        public int? ManaMaxima { get; set; }
        public DateTime DataAt { get; set; }
        public DateTime DataCr { get; set; }

        public virtual Class IdClasseNavigation { get; set; }
    }
}
