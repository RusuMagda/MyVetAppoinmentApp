using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinetesController : ControllerBase
    {
        private readonly ICabinetRepository cabinetRepository;

        public CabinetesController(ICabinetRepository cabinetRepository)
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

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreateCabinetDto dto)
        {
            var cabinet = cabinetRepository.Get(id);
            if (cabinet == null)
            {
                return NotFound();
            }
            cabinetRepository.Update(new Cabinet(dto.Name, dto.Address));
            // petRepository.Save();
            return NoContent();
        }
    }
}
