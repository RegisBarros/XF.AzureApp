using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.AzureApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarAtividade : ContentPage
	{
        public EditarAtividade ()
		{
			InitializeComponent ();

            dteData.MinimumDate = DateTime.Now;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblValorAvaliacao.Text = $"Valor da atividade {sdlValorAvaliacao.Value.ToString("F0")}";
        }
    }
}