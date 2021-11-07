using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace ToggleStore.Web.Services.Usuarios
{
    public class AddRolesClaimsTransformation : IClaimsTransformation
    {
        private readonly IUsuarioService _usuarioService;
        public AddRolesClaimsTransformation(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            // Clone current identity
            var clone = principal.Clone();
            var newIdentity = (ClaimsIdentity)clone.Identity;
            string email = clone.Identity?.Name;
            
            if (string.IsNullOrEmpty(email) || newIdentity == null)
                return Task.FromResult(principal);
            
            PerfilUsuario perfil = _usuarioService.ObterPerfil(email);
            var claim = new Claim("Perfil", perfil.ToString());
            newIdentity.AddClaim(claim);
            return Task.FromResult(clone);
        }
    }
}
