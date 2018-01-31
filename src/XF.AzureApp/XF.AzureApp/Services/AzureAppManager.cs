using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;
using XF.AzureApp.Models;

namespace XF.AzureApp.Services
{
    public class AzureAppManager
    {
        static AzureAppManager Instance = new AzureAppManager();

        MobileServiceClient client;
        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public static AzureAppManager DefaultManager
        {
            get
            {
                return Instance;
            }
            private set
            {
                Instance = value;
            }
        }

        public IMobileServiceTable<Atividade> AtividadeTable { get; set; }

        public AzureAppManager()
        {
            this.client = new MobileServiceClient(Constants.ApplicationURL);

            this.AtividadeTable = client.GetTable<Atividade>();
        }
    }
}
