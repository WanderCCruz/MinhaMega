using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinhaMega.Models
{
    public class ListaMunicipioUFGanhadores
    {
        [JsonPropertyName("ganhadores")]
        public int Ganhadores { get; set; }
        [JsonPropertyName("municipio")]
        public string Municipio { get; set; }
        [JsonPropertyName("nomeFatansiaUL")]
        public string NomeFantasiaUL { get; set; }
        [JsonPropertyName("posicao")]
        public int Posicao { get; set; }
        [JsonPropertyName("serie")]
        public string Serie { get; set; }
        [JsonPropertyName("uf")]
        public string UF { get; set; }
    }
}
