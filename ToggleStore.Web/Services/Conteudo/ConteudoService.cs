using System;
using System.Collections.Generic;
using ToggleStore.Web.Models;

namespace ToggleStore.Web.Services.Conteudo
{
    public class ConteudoService : IConteudoService
    {
        public IEnumerable<ConteudoViewModel> ObterConteudo(CategoriaConteudo categoriaConteudo)
        {
            switch (categoriaConteudo)
            {
                case CategoriaConteudo.Fundamentos:
                    return ObterConteudoFundamentos();
                case CategoriaConteudo.Avancado:
                    return ObterConteudoAvancado();
                case CategoriaConteudo.Arquitetura:
                    return ObterConteudoArquitetura();
                default:
                    throw new ArgumentException($"Não foi possível localizar informações para categoriaConteudo {categoriaConteudo}");
            }
        }

        private IEnumerable<ConteudoViewModel> ObterConteudoArquitetura()
        {
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Arquitetura,
                Nome = "Fundamentos de Arquitetura de Software",
                Descricao = "Conteúdo Sobre Arquitetura de Software",
                Valor = 150,
                Imagem = "arquitetura.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Avancado,
                Nome = "Meu Primeiro Microserviço",
                Descricao = "Fundamentos de desenvolvimento de microserviços",
                Valor = 150,
                Imagem = "microservicos.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Avancado,
                Nome = "Fundamentos de Arquitetura em Nuvem",
                Descricao = "Aprendendo a arquitetar soluções em nuvem usando o Azure",
                Valor = 150,
                Imagem = "azure.png",
            };
        }
        private IEnumerable<ConteudoViewModel> ObterConteudoAvancado()
        {
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Avancado,
                Nome = "Dominando o .NET",
                Descricao = "Conteúdo Avançado Sobre .NET",
                Valor = 50,
                Imagem = "DotNet.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Avancado,
                Nome = "Dominando SQL Server",
                Descricao = "Conteúdo Avançado sobre Sql Server 2019",
                Valor = 50,
                Imagem = "SqlServer.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Avancado,
                Nome = "Dominando Azure",
                Descricao = "Conteúdo Avançado Azure",
                Valor = 50,
                Imagem = "azure.png",
            };
        }
        private IEnumerable<ConteudoViewModel> ObterConteudoFundamentos()
        {
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Fundamentos,
                Nome = "Fundamentos .NET",
                Descricao = "Conteúdo Basico sobre .NET",
                Valor = 25,
                Imagem = "DotNet.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Fundamentos,
                Nome = "Fundamentos SQL Server",
                Descricao = "Conteúdo Basico sobre Sql Server 2019",
                Valor = 25,
                Imagem = "SqlServer.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Fundamentos,
                Nome = "Fundamentos Cloud",
                Descricao = "Conteúdo Basico sobre Cloud em Azure",
                Valor = 25,
                Imagem = "azure.png",
            };
        }
    }
}
