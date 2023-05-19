using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.DTOs;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;
using Pokedex.Infraestructure.Repositories;

namespace Pokedex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeciesController : Controller
    {
        private ISpeciesRepository _speciesRepository;
        private readonly IMapper _mapper;

        public SpeciesController(ISpeciesRepository speciesRepository, IMapper mapper)
        {
            _speciesRepository = speciesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var species = await _speciesRepository.All();
                var speciesDto = _mapper.Map<IEnumerable<SpeciesDto>>(species);
                return Ok(speciesDto);
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
                var specie = await _speciesRepository.Get(id);
                var specieDto = _mapper.Map<SpeciesDto>(specie);
                return Ok(specieDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(SpeciesDto newspecie)
        {
            try
            {
                var specie = _mapper.Map<Species>(newspecie);
                await _speciesRepository.Insert(specie);
                return Ok(specie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(SpeciesDto updatespecie)
        {
            try
            {
                var specie = _mapper.Map<Species>(updatespecie);
                await _speciesRepository.Update(specie);
                return Ok(specie);
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
                var specie = await _speciesRepository.Get(id);
                var deletespecie = await _speciesRepository.Delete(id);
                if (deletespecie)
                    return Ok($"La Especie {specie.Name} fue eliminado correctamente");
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
