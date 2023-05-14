using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinhaMega.Models
{
    public class RateioPremio
    {
        [JsonPropertyName("descricaoFaixa")]
        public string DecricaoFaixa { get; set; }
        [JsonPropertyName("faixa")]
        public int Faixa { get; set; }
        [JsonPropertyName("numeroDeGanhadores")]
        public int NumeroDeGanhadores { get; set; } = 0;
        [JsonPropertyName("valorPremio")]
        public double ValorPremio { get; set; } = 0.0;
    }
}
