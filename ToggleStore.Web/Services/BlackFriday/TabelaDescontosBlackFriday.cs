using System.Collections.Generic;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.BlackFriday
{
    internal static class TabelaDescontosBlackFriday
    {
        internal static IEnumerable<BlackFridayDescontos> Obter()
        {
            yield return new BlackFridayDescontos()
            {
                CategoriaConteudo = CategoriaConteudo.Fundamentos,
                PercentualDesconto = 0.35m
            };
            yield return new BlackFridayDescontos()
            {
                CategoriaConteudo = CategoriaConteudo.Avancado,
                PercentualDesconto = 0.40m
            };
            yield return new BlackFridayDescontos()
            {
                CategoriaConteudo = CategoriaConteudo.Arquitetura,
                PercentualDesconto = 0.50m
            };
            yield return new BlackFridayDescontos()
            {
                CategoriaConteudo = CategoriaConteudo.ClassRoom,
                PercentualDesconto = 0.65m
            };
        }
    }
}