using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using XF.AzureApp.Services;
using XF.AzureApp.Models;
using System.Linq;

namespace XF.AzureApp.ViewModels
{
    public class AtividadeViewModel
    {
        AtividadeService AtividadeService = new AtividadeService();
        Atividade Atividade = new Atividade();

        public List<Atividade> ListaAtividades;
        public async Task Carregar()
        {
            await AtividadeService.ObterAtividades().ContinueWith(retorno =>
            {
                ListaAtividades = retorno.Result.ToList();
            });
            //AplicarFiltro();
        }
        //public void AplicarFiltro()
        //{
        //    if (pesquisaPorNome == null)
        //        pesquisaPorNome = "";

        //    var resultado = ListaAtividades.Where(n => n.Nome.ToLowerInvariant()
        //                        .Contains(PesquisaPorNome.ToLowerInvariant().Trim())).ToList();

        //    var removerDaLista = Atividade.Except(resultado).ToList();
        //    foreach (var item in removerDaLista)
        //    {
        //        Atividade.Remove(item);
        //    }

        //    for (int index = 0; index < resultado.Count; index++)
        //    {
        //        var item = resultado[index];
        //        if (index + 1 > Atividade.Count || !Atividade[index].Equals(item))
        //            Atividade.Insert(index, item);
        //    }
        //}
    }
}
