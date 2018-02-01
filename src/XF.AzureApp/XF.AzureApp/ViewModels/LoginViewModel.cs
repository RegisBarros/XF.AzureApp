using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.AzureApp.Services;
using XF.AzureApp.Views;

namespace XF.AzureApp.ViewModels
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public bool Autenticado { get; set; }

        public UsuarioService UsuarioService => UsuarioService.Instance;

        public ICommand AutenticarCommand => new Command(async () => await Autenticar());

        public async Task Autenticar()
        {
            Autenticado = await UsuarioService.Autorizado(Usuario, Senha);

            if (Autenticado)
            {
                await App.Current.MainPage.Navigation.PushAsync(new AtividadeView());
            }
            else
                await App.Current.MainPage.DisplayAlert("Atenção", "Usuário não autorizado", "Ok");
        }
    }
}
