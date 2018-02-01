using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.AzureApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
        bool authenticated = false;

        public LoginView ()
		{
			InitializeComponent ();
		}

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                if (App.Authenticator != null)
                {
                    authenticated = await App.Authenticator.AuthenticateAsync();
                }

                if (authenticated)
                {
                    Application.Current.MainPage = new AtividadeView();
                }
                else
                {
                    await DisplayAlert("Erro", "Falha na autenticação", "OK");
                }
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("Authentication was cancelled"))
                {
                    await DisplayAlert("Erro", "Autenticação cancelada pelo usuário", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Erro", "Falha na autenticação", "OK");
            }
        }
    }
}