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
            return Ok(cabinetRepository.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCabinetDto dto)
        {
            var cabinet = new Cabinet(dto.Name, dto.Address);
            cabinetRepository.Add(cabinet);
            cabinetRepository.Save();
            return Created(nameof(Get), cabinet);

        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(cabinetRepository.Get(id));
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
        public IActionResult GetClients(Guid id)
        {
            var clients = cabinetRepository.GetClients(id);
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
