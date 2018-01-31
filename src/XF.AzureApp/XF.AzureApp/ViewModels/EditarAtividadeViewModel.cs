using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.AzureApp.Models;
using XF.AzureApp.Services;

namespace XF.AzureApp.ViewModels
{
    public class EditarAtividadeViewModel : NotifyableClass
    {
        private Atividade atividade;
        public Atividade Atividade
        {
            get { return atividade; }
            set { SetProperty(ref atividade, value); }
        }

        public AtividadeService Service => new AtividadeService();

        public ICommand CancelarCommand => new Command(Cancelar);

        public ICommand RegisterCommand => new Command(async () => await Registrar());

        public EditarAtividadeViewModel()
        {
            Atividade = new Atividade();
        }

        public async Task Registrar()
        {
            await Service.Salvar(Atividade);
        }

        public void Cancelar()
        {

        }
    }
}
