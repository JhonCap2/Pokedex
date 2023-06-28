using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public partial class TypesPokemon
    {
        public int PokemonId { get; set; }
        public int TypesId { get; set; }
        public int? Order { get; set; }
        [JsonIgnore]
        public Pokemon? Pokemon { get; set; }
        [JsonIgnore]
        public Types? Types { get; set; }
    }
}
