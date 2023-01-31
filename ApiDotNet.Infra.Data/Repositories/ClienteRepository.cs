using ApiDotNet.Domain.Entities;
using ApiDotNet.Domain.Repositories;
using ApiDotNet.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiDotNet.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDBContext _db;

        public ClienteRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Cliente> CreateAsync(Cliente cliente)
        {
            _db.Add(cliente);
            await _db.SaveChangesAsync();
            return cliente;
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _db.Remove(cliente);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Cliente cliente)
        {
            _db.Update(cliente);
            await _db.SaveChangesAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            return await _db.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Cliente>> GetClienteAsync()
        {
            return await _db.Clientes.ToListAsync();
        }
    }
}
