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
        public int IdPokemon { get; set; }
        public int IdType { get; set; }
        [JsonIgnore]
        [NotMapped]
        public Pokemon? Pokemon { get; set; }
        [JsonIgnore]
        [NotMapped]
        public Types? Types { get; set; }
    }
}
