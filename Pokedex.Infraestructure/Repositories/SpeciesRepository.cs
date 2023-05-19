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
    public class SpeciesRepository : ISpeciesRepository
    {
        private readonly DbPokedexContext _context;

        public SpeciesRepository(DbPokedexContext context)
        {
            _context = context;
        }
        public async Task<List<Species>> All()
        {
            var vspecies = await _context.Species.ToListAsync();
            return vspecies;
        }

        public async Task<bool> Delete(int id)
        {
            var dspecies = await Get(id);
            _context.Species.Remove(dspecies);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

        public async Task<Species> Get(int id)
        {
            var vspecies = await _context.Species.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return vspecies;
        }

        public async Task Insert(Species newSpecies)
        {
            await _context.Species.AddAsync(newSpecies);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Species upSpecies)
        {
            var uspecies = await Get(upSpecies.Id);
            if (uspecies == null)
            { return false; }
            _context.Attach(upSpecies).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
