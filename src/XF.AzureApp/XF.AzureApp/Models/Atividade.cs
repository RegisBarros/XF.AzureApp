using Microsoft.WindowsAzure.MobileServices;
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

        string id;
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public DateTime DataCadastro { get; set; }

        public DateTime DataEntrega { get; set; }

        // parcial ou substitutiva
        public string TipoAvaliacao { get; set; }

        public string Descricao { get; set; }

        // 0 a 10
        public int ValorAvaliacao { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
