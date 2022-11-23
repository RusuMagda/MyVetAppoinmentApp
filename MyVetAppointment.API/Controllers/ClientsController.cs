using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(clientRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var client = clientRepository.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateClientDto dto)
        {
            var client = new Client(dto.Name, dto.EMail, dto.PhoneNumber);
            clientRepository.Add(client);
            clientRepository.Save();
            return Created(nameof(Get), client);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var client = clientRepository.Get(id);
            clientRepository.Delete(client);
            clientRepository.Save();
            return NoContent();
        }

    }
}
