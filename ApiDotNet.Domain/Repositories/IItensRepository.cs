using ApiDotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Domain.Repositories
{
    public interface IItensRepository
    {
        Task<Itens> GetByIdAsync(int id);
        Task<ICollection<Itens>> GetItensAsync();
        Task<Itens> CreateAsync(Itens itens);
        Task EditAsync(Itens itens);
        Task DeleteAsync(Itens itens);
    }
}
