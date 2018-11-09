using ProjectDDD.Domain.Entities;
using ProjectDDD.Domain.Interfaces;
using ProjectDDD.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace ProjectDDD.Domain.Services
{
    public class ProductService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProductService(IProdutoRepository repository) : base(repository)
        {
        }

        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return _produtoRepository.BuscarPorNome(nome);
        }
    }
}