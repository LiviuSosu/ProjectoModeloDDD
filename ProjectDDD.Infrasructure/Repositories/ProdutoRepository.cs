using ProjectDDD.Domain.Entities;
using ProjectDDD.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDDD.Infrasructure.Repositories
{
    public class ProdutoRepository : RepositoryBase<Produto>, IProdutoRepository
    {
        public IEnumerable<Produto> BuscarPorNome(string nome)
        {
            return Db.Produtos.Where(p => p.Nome == nome);
        }
    }
}
