using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaMega.Models
{
    public class RateioPremio
    {
        public string DecricaoFaixa { get; set; }
        public int Faixa { get; set; }
        public int NumeroDeGanhadores { get; set; } = 0;
        public double ValorPremio { get; set; } = 0.0;
    }
}
