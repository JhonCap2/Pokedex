using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public partial class Types
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [NotMapped]
        [JsonIgnore]
        public List<TypesPokemon>? TypesPokemons { get; set; }

    }
}
