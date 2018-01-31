using Newtonsoft.Json;
using System;

namespace XF.AzureApp.Models
{
    public class Atividade
    {
        public Atividade()
        {
            DataCadastro = DateTime.Now;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "dataCadastro")]
        public DateTime DataCadastro { get; set; }

        [JsonProperty(PropertyName = "dataEntrega")]
        public DateTime DataEntrega { get; set; }

        // parcial ou substitutiva
        [JsonProperty(PropertyName = "tipoAvaliacao")]
        public string TipoAvaliacao { get; set; }

        [JsonProperty(PropertyName = "descricao")]
        public string Descricao { get; set; }

        // 0 a 10
        [JsonProperty(PropertyName = "valorAvaliacao")]
        public int ValorAvaliacao { get; set; }
    }
}
