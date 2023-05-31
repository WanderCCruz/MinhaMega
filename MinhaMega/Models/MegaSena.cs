using System.Text.Json.Serialization;

namespace MinhaMega.Models
{
    public class MegaSena
    {
        [JsonPropertyName("numero")]
        public int Numero { get; set; }
        [JsonPropertyName("acumulado")]
        public bool Acumulado { get; set; }
        [JsonPropertyName("dataApuracao")]
        public string DataApuracao { get; set; }
        [JsonPropertyName("dataProximoConcurso")]
        public string DataProximoConcurso { get; set; }
        [JsonPropertyName("listaDezenas")]
        public IList<string> ListaDezenas { get; set; } = new List<string>();
        [JsonPropertyName("listaRateioPremio")]
        public IList<RateioPremio> ListaRateioPremio { get; set; }
        [JsonPropertyName("valorEstimadoProximoConcurso")]
        public double ValorEstimadoProximoConcurso { get; set; } = 0.0;
        [JsonPropertyName("listaMunicipioUFGanhadores")]
        public IList<ListaMunicipioUFGanhadores> ListaMunicipioUFGanhadores { get; set; }

    }
}
