using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;
using Pokedex.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infraestructure.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DbPokedexContext _context;

        public PokemonRepository(DbPokedexContext context)
        {
            _context = context;
        }
        public async Task<List<Pokemon>> All()
        {
            var vpokemon = await _context.Pokemon.Include(x => x.TypesPokemons).ThenInclude(x => x.Types).Include(s => s.Species).ToListAsync();
            return vpokemon;
        }

        public async Task<bool> Delete(int id)
        {
            var dpokemon = await Get(id);
            _context.Pokemon.Remove(dpokemon);
            int row = await _context.SaveChangesAsync();
            return row > 0;
        }

        public async Task<Pokemon> Get(int id)
        {
            var vpokemon = await _context.Pokemon.Include(x => x.TypesPokemons)
                                                 .ThenInclude(x => x.Types)
                                                 .Include(s => s.Species)
                                                 .Include(t => t.Stats)
                                                 .AsNoTracking().SingleOrDefaultAsync(x => x.Pokemon_Number == id); //solucion para que traiga los tipos del pokemon
            return vpokemon;
        }

        public async Task Insert(Pokemon newPokemon)
        {
            await _context.Pokemon.AddAsync(newPokemon);
            _context.SaveChanges();
        }

        public async Task<bool> Update(Pokemon upPokemon)
        {
            var upokemon = await Get(upPokemon.Id);
            if (upokemon == null)
            { return false; }
            _context.Attach(upPokemon).State = EntityState.Modified;
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
