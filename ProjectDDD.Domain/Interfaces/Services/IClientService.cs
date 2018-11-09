using ProjectDDD.Domain.Entities;
using System.Collections.Generic;

namespace ProjectDDD.Domain.Interfaces.Services
{
    public interface IClientService : IServiceBase<Cliente>
    {
        IEnumerable<Cliente> ObterClientsEspecials(IEnumerable<Cliente> clientes);
    }
}
