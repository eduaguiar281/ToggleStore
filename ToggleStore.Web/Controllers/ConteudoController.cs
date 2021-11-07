using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;
using ToggleStore.Web.FeatureToggles;
using ToggleStore.Web.Models;
using ToggleStore.Web.Services.Conteudo;

namespace ToggleStore.Web.Controllers
{
    public class ConteudoController : Controller
    {
        private readonly IConteudoService _conteudoService;
        private readonly IFeatureManager _featureManager;

        public ConteudoController(IConteudoService conteudoService, IFeatureManager featureManager)
        {
            _conteudoService = conteudoService;
            _featureManager = featureManager;
        }

        public IActionResult Fundamentos() => View(_conteudoService.ObterConteudo(CategoriaConteudo.Fundamentos));

        public IActionResult Avancado() => View(_conteudoService.ObterConteudo(CategoriaConteudo.Avancado));

        public IActionResult Arquitetura() => View(_conteudoService.ObterConteudo(CategoriaConteudo.Arquitetura));

        public async Task<IActionResult> ClassRoom()
        {
            if (await _featureManager.IsEnabledAsync(FeatureTogglesConstantes.AcessoClassRoom))
                return View(_conteudoService.ObterConteudo(CategoriaConteudo.ClassRoom));
            return View("/Views/Conteudo/ClassRoomTenhoInteresse.cshtml");
        }
            
    }
}
