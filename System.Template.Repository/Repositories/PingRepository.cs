using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Template.Common.Models;
using System.Template.Repository.Interfaces;
using System.Text;
using System.Threading.Tasks;

namespace System.Template.Repository.Repositories
{
    public class PingRepository : IRepository<Ping>
    {
        private DatabaseContext _context;

        public PingRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task Add(Ping entity)
        {
            _context.Ping.Add(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Ping entity)
        {
            var item = _context.Ping.Find(entity.ID);
            if (item == null)
            {
                return;
            }

            _context.Entry(item).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(Ping entity)
        {
            _context.Ping.Remove(entity);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Ping>> SelectAll()
        {
            return await (from b in _context.Ping
                  orderby b.ID
                  select b).ToListAsync();
        }
        public async Task<Ping> SelectByID(int entityId)
        {
            return await _context.Ping.FirstOrDefaultAsync(x => x.ID.Equals(entityId));
        }
    }
}
