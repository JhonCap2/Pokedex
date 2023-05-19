using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;
using Pokedex.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infraestructure.Repositories
{
    public class StatsRepository : IStatsRepository
    {
        private readonly DbPokedexContext _context;

        public StatsRepository(DbPokedexContext context)
        {
            _context = context;
        }
        public async Task<List<Stats>> All()
        {
            var vstats = await _context.Stats.ToListAsync();
            return vstats;
        }

        public async Task<bool> Delete(int id)
        {
            var dstats = await Get(id);
            _context.Stats.Remove(dstats);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

        public async Task<Stats> Get(int id)
        {
            var vstat = await _context.Stats.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return vstat;
        }

        public async Task Insert(Stats newStats)
        {
            await _context.Stats.AddAsync(newStats);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Stats upStats)
        {
            var ustats = await Get(upStats.Id);
            if (ustats == null)
            { return false; }
            _context.Attach(upStats).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
