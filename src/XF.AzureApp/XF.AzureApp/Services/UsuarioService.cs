using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using XF.AzureApp.Models;

namespace XF.AzureApp.Services
{
    public class UsuarioService
    {
        private UsuarioService() { }

        private static readonly UsuarioService instance = new UsuarioService();
        public static UsuarioService Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<bool> Autorizado(string nome, string senha)
        {
            IEnumerable<Usuario> usuarios = await ObterUsuarios();

            return usuarios.Any(user => user.Nome == nome && user.Senha == senha);
        }

        private async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            var users = new List<Usuario>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string response = await httpClient.GetStringAsync(Constants.UsersURL);

                    if (!string.IsNullOrEmpty(response))
                    {
                        XElement xmlUsers = XElement.Parse(response);

                        foreach (var item in xmlUsers.Elements("User"))
                        {
                            var user = new Usuario()
                            {
                                Nome = item.Element("login").Value,
                                Senha = item.Element("senha").Value
                            };

                            users.Add(user);
                        }
                    }
                }
            }
            catch
            {
                return ObterUsuariosInMemory(); // Caso o recurso esteja fora valida o usuario em memória
            }

            return users;
        }

        private IEnumerable<Usuario> ObterUsuariosInMemory()
        {
            return new List<Usuario>()
            {
                new Usuario()
                {
                    Nome = "admin",
                    Senha = "admin"
                },
                new Usuario()
                {
                    Nome = "usuario",
                    Senha = "usuario"
                }
            };
        }
    }
}
