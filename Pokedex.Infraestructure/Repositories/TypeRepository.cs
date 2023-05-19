using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;
using Pokedex.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infraestructure.Repositories
{
    public class TypeRepository : ITypesRepository
    {
        private readonly DbPokedexContext _context;

        public TypeRepository(DbPokedexContext context)
        {
            _context = context;
        }
        public async Task<List<Types>> All()
        {
            var vtypes = await _context.Types.ToListAsync();
            return vtypes;
        }

        public async Task<bool> Delete(int id)
        {
            var dtype = await Get(id);
            _context.Types.Remove(dtype);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

        public async Task<Types> Get(int id)
        {
            var vtype = await _context.Types.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
            return vtype;
        }

        public async Task Insert(Types newTypes)
        {
            await _context.Types.AddAsync(newTypes);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Types upTypes)
        {
            var utyoe = await Get(upTypes.Id);
            if (utyoe == null)
            { return false; }
            _context.Attach(upTypes).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
