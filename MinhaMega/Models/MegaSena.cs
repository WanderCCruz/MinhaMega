using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaMega.Models
{
    public class MegaSena
    {
        public int Numero { get; set; }
        public bool Acumulado { get; set; }
        public DateTime DataApuracao { get; set; } = new DateTime();
        public DateTime DataProximoConcurso { get; set; } = new DateTime();
        public IList<string> ListaDezenas { get; set; } = new List<string>();
        public IList<RateioPremio> ListaRateioPremio { get; set; }
        public double ValorEstimadoProximoConcurso { get; set; } = 0.0;

    }
}
