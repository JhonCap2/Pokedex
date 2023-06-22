using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public partial class Stats
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Special_Attack { get; set; }
        public int Special_Defense { get; set; }
        public int Speed { get; set; }
        [ForeignKey("PokemonId")]
        [JsonIgnore]
        public int PokemonId { get; set; }
        [JsonIgnore]
        public virtual Pokemon? Pokemon { get; set; }
    }
}
