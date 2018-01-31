using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.AzureApp.ViewModels;

namespace XF.AzureApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarAtividade : ContentPage
	{
        public EditarAtividadeViewModel ViewModel { get; set; }
        public EditarAtividade ()
		{
			InitializeComponent ();

            ViewModel = new EditarAtividadeViewModel();

            BindingContext = ViewModel;

            dteData.MinimumDate = DateTime.Now;
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lblValorAvaliacao.Text = $"Valor da atividade {sdlValorAvaliacao.Value.ToString("F0")}";
        }
    }
}