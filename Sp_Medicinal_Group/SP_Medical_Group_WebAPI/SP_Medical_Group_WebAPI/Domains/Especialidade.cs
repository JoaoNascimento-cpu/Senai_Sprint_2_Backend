﻿using System;
using System.Collections.Generic;

#nullable disable

namespace SP_Medical_Group_WebAPI.Domains
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdEspecialidade { get; set; }
        public string NomeEspecialidade { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
