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
        private readonly IClientRepository clientRepository;
        

        public CabinetesController(ICabinetRepository cabinetRepository, IClientRepository clientRepository)
        {
            this.cabinetRepository = cabinetRepository;
            this.clientRepository = clientRepository;
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
        [HttpGet("{id}/clients")]
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
            cabinetRepository.Update(new Cabinet(dto.Name, dto.Address));
            // petRepository.Save();
            return NoContent();
        }
    }
}
