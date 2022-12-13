using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/Cabinets/")]
    [ApiController]
    public class CabinetsController : ControllerBase
    {
        private readonly ICabinetRepository cabinetRepository;
        private readonly IMapper mapper;

        public CabinetsController(ICabinetRepository cabinetRepository, IMapper mapper)
        {
            this.cabinetRepository = cabinetRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await cabinetRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCabinetDto dto)
        {
            var cabinet = mapper.Map<Cabinet>(dto);
            
            await cabinetRepository.AddAsync(cabinet);
            
            cabinetRepository.Save();
            return Created(nameof(GetAsync), cabinet);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await cabinetRepository.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var cabinet = cabinetRepository.GetByIdAsync(id);
            if (cabinet == null)
            {
                return NotFound();
            }
            cabinetRepository.Delete(id);
            cabinetRepository.Save();
            return NoContent();
        }
        [HttpGet("{id:guid}/clients")]
        public async Task<IActionResult> GetClients(Guid id)
        {
            var clients = await cabinetRepository.GetClientsAsync(id);
            return Ok(clients);
        }
        [HttpGet("shop")]
        public async Task<IActionResult> GetCabinetsWithoutShop()
        {
            var cabinets = await cabinetRepository.GetCabinetsWithoutShop();
            return Ok(cabinets);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreateCabinetDto dto)
        {
            var cabinet = await cabinetRepository.GetByIdAsync(id);
            if (cabinet == null)
            {
                return NotFound();
            }

            mapper.Map(dto, cabinet);

            cabinetRepository.Update(cabinet);
            cabinetRepository.Save();
            return NoContent();
        }
    }
}
