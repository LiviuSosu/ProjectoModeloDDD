using ProjectDDD.Domain.Entities;
using ProjectDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjectDDD.Application
{
    public class ProductAppService : AppServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoService _produtoService;

        public ProductAppService(IProdutoService produtoService) : base(produtoService)
        {
            _produtoService = produtoService;
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoService.BuscarPorNome(nome);
        }
    }
}
