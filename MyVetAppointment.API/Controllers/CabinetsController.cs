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
        public IActionResult Get()
        {
            return Ok(cabinetRepository.GetAllAsync());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCabinetDto dto)
        {
            var cabinet = new Cabinet(dto.Name, dto.Address);
            cabinetRepository.AddAsync(cabinet);
            cabinetRepository.Save();
            return Created(nameof(Get), cabinet);

        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(cabinetRepository.GetByIdAsync(id));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            cabinetRepository.Delete(id);
            cabinetRepository.Save();
            return NoContent();
        }
        [HttpGet("{id:guid}/clients")]
        public IActionResult GetClients(Guid id)
        {
            var clients = cabinetRepository.GetClientsAsync(id);
            return Ok(clients);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreateCabinetDto dto)
        {
            var cabinet = await cabinetRepository.GetByIdAsync(id);
            if (cabinet == null)
            {
                return NotFound();
            }

            cabinet.Address = dto.Address;
            cabinet.Name = dto.Name;

            cabinetRepository.Update(cabinet);
            cabinetRepository.Save();

            return NoContent();
        }
    }
}
