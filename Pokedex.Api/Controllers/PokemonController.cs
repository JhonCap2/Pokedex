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
        private IPokemonRepository _pokemonRepository;
        private readonly IMapper _mapper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
        {
            _pokemonRepository = pokemonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var Pokemon = await _pokemonRepository.All();
                var PokemonDto = _mapper.Map<IEnumerable<PokemonDto>>(Pokemon);
                return Ok(PokemonDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pokemon = await _pokemonRepository.Get(id);
                var pokemonDto = _mapper.Map<PokemonDto>(pokemon);
                return Ok(pokemonDto);
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
                await _pokemonRepository.Insert(pokemon);
                return Ok(pokemon);
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
        public async Task<IActionResult> DeletePokemon(int id)
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
