using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.DTOs
{
    public class VisualisePokemonDTO
    {
        public int Id { get; set; }
        public int Pokemon_Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<string>? TypesPokemons { get; set; }
        public string Specie { get; set; } = string.Empty;
        public Stats? Stats { get; set; }
    }
}
