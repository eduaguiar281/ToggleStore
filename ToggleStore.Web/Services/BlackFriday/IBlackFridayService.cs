using System.Collections.Generic;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.BlackFriday
{
    public interface IBlackFridayService
    {
        IEnumerable<ConteudoViewModel> AplicarDesconto(IEnumerable<ConteudoViewModel> conteudos);
    }
}
