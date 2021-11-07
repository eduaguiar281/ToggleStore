using System;

namespace ToggleStore.Web.Models
{
    [Flags]
    public enum CategoriaConteudo
    {
        None = 0,
        Fundamentos = 1,
        Avancado = 2,
        Arquitetura = 4
    }
}