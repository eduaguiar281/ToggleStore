using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.FeatureManagement;
using ToggleStore.Web.Services.Usuarios;

namespace ToggleStore.Web.FeatureToggles.CustomFilters
{
    [FilterAlias(FeatureTogglesConstantes.PerfilFilter)]
    public class PerfilFeatureFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PerfilFeatureFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            ClaimsPrincipal user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
                return Task.FromResult(false);

            string perfilNome = user.Claims.FirstOrDefault(x => x.Type == "Perfil")?.Value;
            if (! Enum.TryParse(perfilNome, true, out PerfilUsuario perfil))
                return Task.FromResult(false);


            PerfilFilterSettings settings = context.Parameters.Get<PerfilFilterSettings>();
            return Task.FromResult(settings.PerfisPermitidos.HasFlag(perfil));
        }

	}
}
