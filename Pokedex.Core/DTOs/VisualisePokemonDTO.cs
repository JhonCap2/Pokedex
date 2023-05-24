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
        public string Image { get; set; } = string.Empty;
        
        public List<string>? TypesPokemons { get; set; }
        //public List<string> TypesName
        //{
        //    get
        //    {
        //        return TypesPokemons?.Where(x =>x.PokemonId == Id).Select(x => x.Types.Name).ToList() ?? new List<string>();
        //    }
        //} 
    }
}
