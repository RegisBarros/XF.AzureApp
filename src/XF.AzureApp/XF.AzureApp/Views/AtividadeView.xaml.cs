using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.AzureApp.ViewModels;

namespace XF.AzureApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AtividadeView : ContentPage
    {
        public AtividadeViewModel AtividadeViewModel { get; set; }

        public AtividadeView()
        {
            AtividadeViewModel = new AtividadeViewModel();

            BindingContext = AtividadeViewModel;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
            await AtividadeViewModel.Carregar();
            lstAtividades.IsRefreshing = !lstAtividades.IsRefreshing;
        }
    }
}