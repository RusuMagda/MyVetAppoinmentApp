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
        

        public CabinetsController(ICabinetRepository cabinetRepository)
        {
            this.cabinetRepository = cabinetRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await cabinetRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateCabinetDto dto)
        {
            var cabinet = new Cabinet(dto.Name, dto.Address);
            
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
            var cabinet = cabinetRepository.Get(id);
            if (cabinet == null)
            {
                return NotFound();
            }
            cabinetRepository.Delete(cabinet);
            cabinetRepository.Save();
            return NoContent();
        }
        [HttpGet("{id:guid}/clients")]
        public async Task<IActionResult> GetClients(Guid id)
        {
            var clients = await cabinetRepository.GetClientsAsync(id);
            return Ok(clients);
        }


        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreateCabinetDto dto)
        {
            var cabinet = cabinetRepository.Get(id);
            if (cabinet == null)
            {
                return NotFound();
            }
            cabinet.Name = dto.Name;
            cabinet.Address = dto.Address;

            cabinetRepository.Update(cabinet);
            cabinetRepository.Save();
            return NoContent();
        }
    }
}
