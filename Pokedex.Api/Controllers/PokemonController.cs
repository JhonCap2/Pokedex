using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.DTOs;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;

namespace Pokedex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly ITypesRepository _typesRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, ITypesRepository typesRepository , IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _typesRepository = typesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<VisualisePokemonsDTO>>> All()
        {
            var Pokemon = await _pokemonRepository.All();
            var Types = await _typesRepository.All();

            List<VisualisePokemonsDTO> modelDTO = new();

            try
            {
                foreach (var pokemon in Pokemon)
                {
                    var typesNames = new List<string>();

                    foreach (var typesPokemon in pokemon?.TypesPokemons.OrderBy(x => x.Order))
                    {
                        if (typesPokemon.PokemonId == pokemon.Id && typesPokemon.Types != null)
                        {
                            typesNames.Add(typesPokemon.Types.Name);
                        }
                    }

                    modelDTO.Add(new VisualisePokemonsDTO
                    {
                        Id = pokemon.Id,
                        Image = pokemon.Image,
                        Name = pokemon.Name,
                        Pokemon_Number = pokemon.Pokemon_Number,
                        TypesPokemons = typesNames
                    });
                }

                return modelDTO;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Type")]
        public async Task<IActionResult> PokemonByType([FromQuery] string type)
        {
            var Pokemon = await _pokemonRepository.GetPokemonByType(type);


            List<VisualisePokemonsDTO> modelDTO = new();


            try
            {
                foreach (var pokemon in Pokemon)
                {
                    var typesNames = new List<string>();

                    foreach (var typesPokemon in pokemon?.TypesPokemons)
                    {
                        if (typesPokemon.PokemonId == pokemon.Id && typesPokemon.Types != null)
                        {
                            typesNames.Add(typesPokemon.Types.Name);
                        }
                    }

                    modelDTO.Add(new VisualisePokemonsDTO
                    {
                        Id = pokemon.Id,
                        Image = pokemon.Image,
                        Name = pokemon.Name,
                        Pokemon_Number = pokemon.Pokemon_Number,
                        TypesPokemons = typesNames
                    });
                }

                return Ok(modelDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Pokemon = await _pokemonRepository.Get(id);
            var Evolutions = await _pokemonRepository.GetPokemonEvolutions((int)Pokemon.EvolutionFamilyId);

            if (Pokemon == null)
            {
                return NotFound();
            }

            try
            {
                var typesNames = new List<string>();

                foreach (var typesPokemon in Pokemon?.TypesPokemons.OrderBy(x => x.Order))
                {
                    if (typesPokemon.PokemonId == Pokemon.Id && typesPokemon.Types != null)
                    {
                        typesNames.Add(typesPokemon.Types.Name);
                    }
                }

                List<PokemonDto> PokemonEvolution = new();

                foreach (var evolution in Evolutions)
                {
                    var EvolutionTypes = new List<string>();

                    foreach (var type in evolution.TypesPokemons.OrderBy(x => x.Order))
                    {
                        EvolutionTypes.Add(type.Types.Name);
                    }

                    PokemonEvolution.Add(new PokemonDto
                    {
                        Name = evolution.Name,
                        Pokemon_Number = evolution.Pokemon_Number,
                        Image = evolution.Image,
                        EvolutionFamilyId = (int)evolution.EvolutionFamilyId,
                        OrderEvolution = (int)evolution.OrderEvolution,
                        TypesPokemons = EvolutionTypes
                    });
                }

                VisualisePokemonDTO modelDTO = new()
                {
                    Id = Pokemon.Id,
                    Image = Pokemon.Image,
                    Name = Pokemon.Name,
                    Description = Pokemon.Description,
                    Weight = Pokemon.Weight,
                    Height = Pokemon.Heigth,
                    Pokemon_Number = Pokemon.Pokemon_Number,
                    Specie = Pokemon.Species.Name,
                    TypesPokemons = typesNames,
                    Stats = Pokemon.Stats,
                    PokemonEvolutions = PokemonEvolution
                };

                return Ok(modelDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(PokemonDto newPokemon)
        {
            try
            {
                var pokemon = _mapper.Map<Pokemon>(newPokemon);

                if (pokemon.TypesPokemons != null)
                {
                    for (int i = 0; i < newPokemon.TypesPokemons.Count; i++)
                    {
                        pokemon.TypesPokemons[i].Order = i;
                    }
                }
                await _pokemonRepository.Insert(pokemon);
                return Ok($"Pokemon {pokemon.Name} creado con exito");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PokemonDto updatePokemon)
        {
            try
            {
                var pokemon = _mapper.Map<Pokemon>(updatePokemon);
                await _pokemonRepository.Update(pokemon);
                return Ok(pokemon);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var pokemon = await _pokemonRepository.Get(id);
                var deletePokemon = await _pokemonRepository.Delete(id);
                if (deletePokemon)
                    return Ok($"El Pokemon {pokemon.Name} fue eliminado correctamente");
                else
                    return StatusCode(500, $"Operación no procesada o el GUID '{id}' no existe.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
