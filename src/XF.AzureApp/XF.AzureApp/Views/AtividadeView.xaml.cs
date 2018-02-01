using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using XF.AzureApp.Models;
using XF.AzureApp.Services;
using XF.AzureApp.ViewModels;

namespace XF.AzureApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtividadeView : ContentPage
    {
        AtividadeViewModel atividadeViewModel = new AtividadeViewModel();
        public AtividadeView()
        {
            BindingContext = atividadeViewModel;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
            await atividadeViewModel.Carregar();
            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
        }
        async void AddAtividadeButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditarAtividade());
        }

    }
}