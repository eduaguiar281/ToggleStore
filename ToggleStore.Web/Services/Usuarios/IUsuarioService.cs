using System.Security.Claims;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.Usuarios
{
    public interface IUsuarioService
    {
        bool ConteudoLiberado(CategoriaConteudo categoria, ClaimsPrincipal user);
        PerfilUsuario ObterPerfil(string email);
    }
}
