using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public class Evolutions
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PokemonId { get; set; }
        public virtual List<Pokemon>? Pokemon { get; set; }
    }
}
