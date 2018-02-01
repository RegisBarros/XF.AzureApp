using System;
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

        public ICommand CancelarCommand => new Command(async () => await Cancelar());

        public ICommand RegisterCommand => new Command(async () => await Registrar());

        public async Task Registrar()
        {
            try
            {
                await Service.Salvar(Atividade);

                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK"); 
            }
        }

        public async Task Cancelar()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
