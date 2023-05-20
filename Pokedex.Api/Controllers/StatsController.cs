using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.DTOs;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;

namespace Pokedex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : Controller
    {
        private IStatsRepository _statsRepository;
        private readonly IMapper _mapper;

        public StatsController(IStatsRepository statsRepository, IMapper mapper)
        {
            _statsRepository = statsRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var stats = await _statsRepository.All();
                var statsDto = _mapper.Map<IEnumerable<StatsDto>>(stats);
                return Ok(statsDto);
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
                var stat = await _statsRepository.Get(id);
                var statDto = _mapper.Map<StatsDto>(stat);
                return Ok(statDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(StatsDto newStats)
        {
            try
            {
                var stats = _mapper.Map<Stats>(newStats);
                await _statsRepository.Insert(stats);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(StatsDto updatestats)
        {
            try
            {
                var stats = _mapper.Map<Stats>(updatestats);
                await _statsRepository.Update(stats);
                return Ok(stats);
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
                var stats = await _statsRepository.Get(id);
                var deleteStats = await _statsRepository.Delete(id);
                if (deleteStats)
                    return Ok($"Los stats del pokemon fueron eliminado correctamente");
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
