using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Interface
{
    public interface IStatsRepository
    {
        Task<List<Stats>> All();
        Task<Stats> Get(int id);
        Task Insert(Stats newStats);
        Task<bool> Update(Stats upStats);
        Task<bool> Delete(int id);
    }
}
