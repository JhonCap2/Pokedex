using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pokedex.Core.Entities
{
    public partial class Species
    {

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [JsonIgnore]
        public virtual List<Pokemon>? Pokemon { get; set; }
    }
}
