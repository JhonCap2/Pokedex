using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Interface
{
    public interface ISpeciesRepository
    {
        Task<List<Species>> All();
        Task<Species> Get(int id);
        Task Insert(Species newSpecies);
        Task<bool> Update(Species upSpecies);
        Task<bool> Delete(int id);
    }
}
