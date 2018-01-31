using System.Threading.Tasks;

namespace XF.AzureApp.Services
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync();

        Task<bool> LogoutAsync();
    }
}
