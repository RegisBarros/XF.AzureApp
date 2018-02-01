
using Xamarin.Forms;
using XF.AzureApp.Services;
using XF.AzureApp.ViewModels;
using XF.AzureApp.Views;

namespace XF.AzureApp
{
    public partial class App : Application
    {
        public static IAuthenticate Authenticator { get; private set; }

        public static LoginViewModel LoginViewModel { get; set; }

        public App()
        {
            InitializeComponent();

            if (LoginViewModel == null)
                LoginViewModel = new LoginViewModel();

            MainPage = new NavigationPage(new LoginView() { BindingContext = LoginViewModel });
        }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
