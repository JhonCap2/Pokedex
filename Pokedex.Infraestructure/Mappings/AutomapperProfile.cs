using AutoMapper;
using Pokedex.Core.DTOs;
using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Pokemon, PokemonDto>().ReverseMap();
            CreateMap<Species, SpeciesDto>().ReverseMap();
            CreateMap<Stats, StatsDto>().ReverseMap();
            CreateMap<Types, TypeDto>().ReverseMap();
            CreateMap<TypesPokemon, TypesPokemonDto>().ReverseMap();
        }
    }
}
