using ProjectDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjectDDD.Application.Interfaces
{
    public interface IClienteAppService : IAppServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientsEspecials();
    }
}
