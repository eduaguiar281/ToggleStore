using System.Collections.Generic;
using System.Linq;
using Microsoft.FeatureManagement;
using ToggleStore.Web.FeatureToggles;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.BlackFriday
{
    public class BlackFridayService : IBlackFridayService
    {
        private readonly IEnumerable<BlackFridayDescontos> _descontos;
        private readonly IFeatureManager _featureManager;

        public BlackFridayService(IFeatureManager featureManager)
        {
            _descontos = TabelaDescontosBlackFriday.Obter();
            _featureManager = featureManager;
        }
        public IEnumerable<ConteudoViewModel> AplicarDesconto(IEnumerable<ConteudoViewModel> conteudos)
        {
            if (!_featureManager.IsEnabledAsync(FeatureTogglesConstantes.BlackFriday).Result)
                return conteudos;

            List<ConteudoViewModel> results = new List<ConteudoViewModel>();
            foreach (var conteudo in conteudos)
            {
                CalculaDesconto(conteudo);
                results.Add(conteudo);
            }
            return results;
        }

        private void CalculaDesconto(ConteudoViewModel conteudo)
        {
            BlackFridayDescontos desconto =
                _descontos.FirstOrDefault(d => d.CategoriaConteudo == conteudo.CategoriaConteudo);
            if (desconto == null)
                return;
            decimal descontoValor = conteudo.Valor * desconto.PercentualDesconto;
            conteudo.PercentualDesconto = desconto.PercentualDesconto;
            conteudo.ValorComDesconto = conteudo.Valor - descontoValor;
        }
    }
}
