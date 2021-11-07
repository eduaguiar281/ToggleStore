using System;
using System.Linq;
using System.Security.Claims;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.Usuarios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly string[] _usuariosPadrao = new string[]
        {
            "padrao@gmail.com",
            "padrao@hotmail.com",
            "padrao@contoso.com.br"
        };

        private readonly string[] _usuariosExpert = new string[]
        {
            "expert@gmail.com",
            "expert@hotmail.com",
            "expert@contoso.com.br"
        };

        private readonly string[] _usuariosPremium = new string[]
        {
            "premium@gmail.com",
            "premium@hotmail.com",
            "premium@contoso.com.br",
        };

        private readonly string[] _usuariosExclusivo = new string[]
        {
            "exclusivo@gmail.com",
            "exclusivo@hotmail.com",
            "exclusivo@contoso.com.br"
        };

        private CategoriaConteudo ConteudoLiberado(string email)
        {
            if (_usuariosPadrao.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return CategoriaConteudo.Fundamentos;
            if (_usuariosExpert.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return CategoriaConteudo.Fundamentos | CategoriaConteudo.Avancado;
            if (_usuariosPremium.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return CategoriaConteudo.Fundamentos | CategoriaConteudo.Avancado | CategoriaConteudo.Arquitetura;
            if (_usuariosExclusivo.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return CategoriaConteudo.Fundamentos | CategoriaConteudo.Avancado | CategoriaConteudo.Arquitetura;

            return CategoriaConteudo.None;
        }

        public bool ConteudoLiberado(CategoriaConteudo categoria, ClaimsPrincipal user)
        {
            if (user == null || user.Identity == null)
                return false;
            CategoriaConteudo categoriasLiberadas = ConteudoLiberado(user.Identity.Name);
            return categoriasLiberadas.HasFlag(categoria);
        }

        public PerfilUsuario ObterPerfil(string email)
        {
            if (_usuariosPadrao.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return PerfilUsuario.Padrao;
            if (_usuariosExpert.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return PerfilUsuario.Expert;
            if (_usuariosPremium.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return PerfilUsuario.Premium;
            if (_usuariosExclusivo.Any(u => u.Equals(email, StringComparison.OrdinalIgnoreCase)))
                return PerfilUsuario.Exclusivo;

            return PerfilUsuario.None;
        }
    }
}
