using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class JogoDomain
    {
        /// <summary>
        /// Id dos jogos listados
        /// </summary>
        public int idJogo { get; set; }
        /// <summary>
        /// Nome dos jogos listados
        /// </summary>
        public string nomeJogo { get; set; }
        /// <summary>
        /// Nome dos jogos listados
        /// </summary>
        public string descricao { get; set; }
        /// <summary>
        /// Data de lançamento dos jogos listados
        /// </summary>
        public DateTime dataDeLancamento { get; set; }
        /// <summary>
        /// Valor dos jogos listados
        /// </summary>
        public decimal valor { get; set; }
        /// <summary>
        /// Ids dos estudios que fizeram cada jogo especificamente
        /// </summary>
        public int idEstudio { get; set; }
    }
}
