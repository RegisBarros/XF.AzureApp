using Microsoft.Azure.Mobile.Server;
using System;

namespace fiap_azure_appService.DataObjects
{
    public class Atividade: EntityData
    {
        public DateTime DataCadastro { get; set; }

        public DateTime DataEntrega { get; set; }

        public string TipoAvaliacao { get; set; }

        public string Descricao { get; set; }

        public int ValorAvaliacao { get; set; }
    }
}