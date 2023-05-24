using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.DTOs
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public int Pokemon_Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Heigth { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public int? SpeciesId { get; set; }
        public virtual List<TypesPokemon>? TypesPokemons { get; set; }
        public virtual Stats? Stats { get; set; }
        [JsonIgnore]
        public virtual Species? Species { get; set; }
    }
}
