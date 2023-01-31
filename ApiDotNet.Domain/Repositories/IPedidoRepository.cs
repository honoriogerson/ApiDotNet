using ApiDotNet.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Domain.Repositories
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetByIdAsync(int id);

        Task<ICollection<Pedido>> GetPedidoeAsync();

        Task<Pedido> CreateAsync(Pedido pedido);

        Task EditAsync(Pedido pedido);

        Task DeleteAsync(Pedido pedido);
    }
}
