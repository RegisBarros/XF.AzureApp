using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.AzureApp.Models;
using XF.AzureApp.Services;
using XF.AzureApp.Views;

namespace XF.AzureApp.ViewModels
{
    public class AtividadeViewModel : NotifyableClass
    {
        public AtividadeService AtividadeService => new AtividadeService();

        public List<Atividade> ListaAtividades;

        public ObservableCollection<Atividade> Atividades { get; set; } = new ObservableCollection<Atividade>();

        private string pesquisaPorNome;
        public string PesquisaPorNome
        {
            get { return pesquisaPorNome; }
            set
            {
                SetProperty(ref pesquisaPorNome, value);

                AplicarFiltro();
            }
        }

        public ICommand NovoCommand => new Command(async () => await Novo());

        public AtividadeViewModel()
        {
            ListaAtividades = new List<Atividade>();
        }

        public async Task Carregar()
        {
            await AtividadeService.ObterAtividades().ContinueWith(retorno =>
            {
                ListaAtividades = retorno.Result.ToList();
            });

            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            if (pesquisaPorNome == null)
                pesquisaPorNome = "";

            var resultado = ListaAtividades.Where(n => n.Descricao.ToLowerInvariant()
                                .Contains(PesquisaPorNome.ToLowerInvariant().Trim())).ToList();

            var removerDaLista = Atividades.Except(resultado).ToList();
            foreach (var item in removerDaLista)
            {
                Atividades.Remove(item);
            }

            for (int index = 0; index < resultado.Count; index++)
            {
                var item = resultado[index];
                if (index + 1 > Atividades.Count || !Atividades[index].Equals(item))
                    Atividades.Insert(index, item);
            }
        }

        public async Task Novo()
        {
            await App.Current.MainPage.Navigation.PushAsync(
                new EditarAtividade { BindingContext = new EditarAtividadeViewModel() { Atividade = new Atividade() } });
        }
    }
}
