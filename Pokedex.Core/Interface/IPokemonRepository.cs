using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Core.Entities;

namespace Pokedex.Core.Interface
{
    public interface IPokemonRepository
    {
        Task<List<Pokemon>> All();
        Task<Pokemon> Get(int id);
        Task Insert(Pokemon newPokemon);
        Task<bool> Update(Pokemon upPokemon);
        Task<bool> Delete(int id);
    }
}
