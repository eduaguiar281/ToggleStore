using System.Collections.Generic;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.Conteudo
{
    public interface IConteudoService
    {
        IEnumerable<ConteudoViewModel> ObterConteudo(CategoriaConteudo categoriaConteudo);
    }
}
