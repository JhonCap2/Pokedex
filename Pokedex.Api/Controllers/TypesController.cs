using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.DTOs;
using Pokedex.Core.Entities;
using Pokedex.Core.Interface;

namespace Pokedex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : Controller
    {
        private ITypesRepository _typesRepository;
        private readonly IMapper _mapper;

        public TypesController(ITypesRepository typesRepository, IMapper mapper)
        {
            _typesRepository = typesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            try
            {
                var types = await _typesRepository.All();
                var typesDto = _mapper.Map<IEnumerable<TypeDto>>(types);
                return Ok(typesDto);
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
                var type = await _typesRepository.Get(id);
                var typeDto = _mapper.Map<TypeDto>(type);
                return Ok(typeDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TypeDto newType)
        {
            try
            {
                var types = _mapper.Map<Types>(newType);
                await _typesRepository.Insert(types);
                return Ok(types);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TypeDto updateType)
        {
            try
            {
                var types = _mapper.Map<Types>(updateType);
                await _typesRepository.Update(types);
                return Ok(types);
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
                var types = await _typesRepository.Get(id);
                var deletetypes = await _typesRepository.Delete(id);
                if (deletetypes)
                    return Ok($"El tipo {types.Name} fue eliminado correctamente");
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
