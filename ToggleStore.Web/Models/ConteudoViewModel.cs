using System;
using System.Collections.Generic;

namespace ToggleStore.Web.Models
{
    public class ConteudoViewModel
    {
        public Guid Id { get; set; }

        public CategoriaConteudo CategoriaConteudo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }
        public decimal ValorComDesconto { get; set; }
        public decimal PercentualDesconto { get; set; }
        public string Imagem { get; set; }
    }

}
