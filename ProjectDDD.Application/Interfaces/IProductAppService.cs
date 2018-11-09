using ProjectDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjectDDD.Application.Interfaces
{
    public interface IProductAppService : IAppServiceBase<Produto>
    {
        IEnumerable<Produto> BuscarPorNome(string nome);
    }
}
