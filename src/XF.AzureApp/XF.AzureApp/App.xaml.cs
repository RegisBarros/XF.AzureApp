using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.AzureApp.Services;
using XF.AzureApp.Views;

namespace XF.AzureApp
{
	public partial class App : Application
	{
        public static IAuthenticate Authenticator { get; private set; }

        public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new EditarAtividade());
            //MainPage = new XF.AzureApp.MainPage();
            MainPage = new NavigationPage(new HomeView());
        }

        public static void Init(IAuthenticate authenticator)
        {
            Authenticator = authenticator;
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
