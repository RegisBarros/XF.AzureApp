using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XF.AzureApp.Models;

namespace XF.AzureApp.Services
{
    public class AtividadeService
    {
        public async Task<ObservableCollection<Atividade>> ObterAtividades()
        {
            try
            {
                IEnumerable<Atividade> atividades = await AzureAppManager.DefaultManager.AtividadeTable
                    .OrderByDescending(a => a.DataEntrega)
                    .ToEnumerableAsync();

                return new ObservableCollection<Atividade>(atividades);
            }
            catch (MobileServiceInvalidOperationException error)
            {
                await App.Current.MainPage.DisplayAlert("Erro", error.Message, "OK");
            }
            catch (Exception error)
            {
                await App.Current.MainPage.DisplayAlert("Erro", error.Message, "OK");
            }

            return null;
        }


        public async Task Salvar(Atividade atividade)
        {
            if (atividade.Id == null)
            {
                await AzureAppManager.DefaultManager.AtividadeTable.InsertAsync(atividade);
            }
            else
            {
                await AzureAppManager.DefaultManager.AtividadeTable.UpdateAsync(atividade);
            }
        }
    }
}
