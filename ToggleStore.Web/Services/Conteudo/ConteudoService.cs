using System;
using System.Collections.Generic;
using ToggleStore.Web.Models;
using ToggleStore.Web.Services.BlackFriday;

namespace ToggleStore.Web.Services.Conteudo
{
    public class ConteudoService : IConteudoService
    {
        private readonly IBlackFridayService _blackFridayService;

        public ConteudoService(IBlackFridayService blackFridayService)
        {
            _blackFridayService = blackFridayService;   
        }

        public IEnumerable<ConteudoViewModel> ObterConteudo(CategoriaConteudo categoriaConteudo)
        {
            switch (categoriaConteudo)
            {
                case CategoriaConteudo.Fundamentos:
                    return _blackFridayService.AplicarDesconto(ObterConteudoFundamentos());
                case CategoriaConteudo.Avancado:
                    return _blackFridayService.AplicarDesconto(ObterConteudoAvancado());
                case CategoriaConteudo.Arquitetura:
                    return _blackFridayService.AplicarDesconto(ObterConteudoArquitetura());
                case CategoriaConteudo.ClassRoom:
                    return _blackFridayService.AplicarDesconto(ObterConteudoClassRoom());
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
                CategoriaConteudo = CategoriaConteudo.Arquitetura,
                Nome = "Meu Primeiro Microserviço",
                Descricao = "Fundamentos de desenvolvimento de microserviços",
                Valor = 150,
                Imagem = "microservicos.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.Arquitetura,
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
        private IEnumerable<ConteudoViewModel> ObterConteudoClassRoom()
        {
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.ClassRoom,
                Nome = "DDD na Prática",
                Descricao = "Vamos te ajudar a dominar o DDD",
                Valor = 250,
                Imagem = "dddNaPratica.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.ClassRoom,
                Nome = "CQRS na Prática",
                Descricao = "Vamos te ajudar a dominar o CQRS",
                Valor = 250,
                Imagem = "CQRS.png",
            };
            yield return new()
            {
                Id = Guid.NewGuid(),
                CategoriaConteudo = CategoriaConteudo.ClassRoom,
                Nome = "Dominando RabbitMQ",
                Descricao = "Vamos te ajudar a dominar o RabbitMQ",
                Valor = 250,
                Imagem = "rabbit.png",
            };
        }
    }
}
