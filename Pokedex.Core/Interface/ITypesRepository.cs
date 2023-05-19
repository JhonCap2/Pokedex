using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Interface
{
    public interface ITypesRepository
    {
        Task<List<Types>> All();
        Task<Types> Get(int id);
        Task Insert(Types newTypes);
        Task<bool> Update(Types upTypes);
        Task<bool> Delete(int id);
    }
}
