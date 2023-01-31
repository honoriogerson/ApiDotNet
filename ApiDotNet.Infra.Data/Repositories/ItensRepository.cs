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
    public class ItensRepository : IItensRepository
    {
        private readonly ApplicationDBContext _db;

        public ItensRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Itens> CreateAsync(Itens itens)
        {
            _db.Add(itens);
            await _db.SaveChangesAsync();
            return itens;
        }

        public async Task DeleteAsync(Itens itens)
        {
            _db.Remove(itens);
            await _db.SaveChangesAsync();
        }

        public async Task EditAsync(Itens itens)
        {
            _db.Update(itens);
            await _db.SaveChangesAsync();
        }

        public async Task<ICollection<Itens>> GetItensAsync()
        {
            return await _db.Item.ToListAsync();
        }

        public async Task<Itens> GetByIdAsync(int id)
        {
            return await _db.Item.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
