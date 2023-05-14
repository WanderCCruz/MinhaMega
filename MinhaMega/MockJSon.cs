﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MinhaMega
{
    public class MockJSon
    {
        public string MegaSenaString()
        {
            return @"{
  ""acumulado"": false,
  ""dataApuracao"": ""11/05/2023"",
  ""dataProximoConcurso"": ""13/05/2023"",
  ""dezenasSorteadasOrdemSorteio"": [
    ""30"",
    ""28"",
    ""23"",
    ""11"",
    ""21"",
    ""10""
  ],
  ""exibirDetalhamentoPorCidade"": true,
  ""id"": null,
  ""indicadorConcursoEspecial"": 1,
  ""listaDezenas"": [
    ""10"",
    ""11"",
    ""21"",
    ""23"",
    ""28"",
    ""30""
  ],
  ""listaDezenasSegundoSorteio"": null,
  ""listaMunicipioUFGanhadores"": [
    {
      ""ganhadores"": 1,
      ""municipio"": ""ITANHANGA"",
      ""nomeFatansiaUL"": """",
      ""posicao"": 1,
      ""serie"": """",
      ""uf"": ""MT""
    }
  ],
  ""listaRateioPremio"": [
    {
      ""descricaoFaixa"": ""6 acertos"",
      ""faixa"": 1,
      ""numeroDeGanhadores"": 1,
      ""valorPremio"": 43295767.4
    },
    {
      ""descricaoFaixa"": ""5 acertos"",
      ""faixa"": 2,
      ""numeroDeGanhadores"": 116,
      ""valorPremio"": 31279.23
    },
    {
      ""descricaoFaixa"": ""4 acertos"",
      ""faixa"": 3,
      ""numeroDeGanhadores"": 7633,
      ""valorPremio"": 679.07
    }
  ],
  ""listaResultadoEquipeEsportiva"": null,
  ""localSorteio"": ""ESPAÇO DA SORTE"",
  ""nomeMunicipioUFSorteio"": ""SÃO PAULO, SP"",
  ""nomeTimeCoracaoMesSorte"": ""\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000\u0000"",
  ""numero"": 2591,
  ""numeroConcursoAnterior"": 2590,
  ""numeroConcursoFinal_0_5"": 2595,
  ""numeroConcursoProximo"": 2592,
  ""numeroJogo"": 2,
  ""observacao"": """",
  ""premiacaoContingencia"": null,
  ""tipoJogo"": ""MEGA_SENA"",
  ""tipoPublicacao"": 3,
  ""ultimoConcurso"": true,
  ""valorArrecadado"": 62932260.0,
  ""valorAcumuladoConcurso_0_5"": 7558662.93,
  ""valorAcumuladoConcursoEspecial"": 42171861.2,
  ""valorAcumuladoProximoConcurso"": 0.0,
  ""valorEstimadoProximoConcurso"": 3000000.0,
  ""valorSaldoReservaGarantidora"": 0.0,
  ""valorTotalPremioFaixaUm"": 0.0
}";
        }
    }
}
