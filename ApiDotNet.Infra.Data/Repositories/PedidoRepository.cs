using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDBContext _db;

        public PedidoRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _db.Add(pedido);
            await _db.SaveChangesAsync();
            return pedido;
        }

        public async Task DeleteAsync(Pedido pedido)
        {
            _db.Remove(pedido);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Pedido pedido)
        {
            _db.Update(pedido);
            await _db.SaveChangesAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            return await _db.Pedidos
                .Include(x => x.Cliente)
                .Include(x => x.Itens)
                .FirstOrDefaultAsync(x => x.Id == id);
        }             

        public async Task<ICollection<Pedido>> GetPedidoeAsync()
        {
            return await _db.Pedidos
                .Include(x => x.Cliente)
                .Include(x => x.Itens)
                .ToListAsync();
        }
    }
}
