using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public partial class Pokemon
    {
        public int Id { get; set; }
        public int Pokemon_Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Heigth { get; set; } = string.Empty;
        public string Weight { get; set; } = string.Empty;
        public int? SpeciesId { get; set; }
        public int? EvolutionFamilyId { get; set; }
        public int? OrderEvolution { get; set; }
        public virtual List<TypesPokemon>? TypesPokemons { get; set; }
        public virtual Stats? Stats { get; set; }
        [JsonIgnore]
        public virtual Species? Species { get; set; }
        [JsonIgnore]
        public virtual Evolutions? EvolutionFamily { get; set; }
    }

    
}
