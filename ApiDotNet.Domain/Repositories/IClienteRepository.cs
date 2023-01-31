using ApiDotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<Cliente> GetByIdAsync(int id);
        
        Task<ICollection<Cliente>> GetClienteAsync();

        Task<Cliente> CreateAsync(Cliente cliente);

        Task EditAsync(Cliente cliente);

        Task DeleteAsync(Cliente cliente);      
    }
}
