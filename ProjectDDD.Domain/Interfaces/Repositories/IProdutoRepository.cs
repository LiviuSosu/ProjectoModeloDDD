using ProjectDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjectDDD.Domain.Interfaces
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
