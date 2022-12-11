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
            return Ok(clientRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var client = clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpGet("{id:guid}/pets")]
        public IActionResult GetPets(Guid id)
        {
            var client = clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var pets = clientRepository.GetAllPetsAsync(id);
            return Ok(pets);
        }


        [HttpPost]
        public IActionResult Create([FromBody] CreateClientDto dto)
        {
            var client = new Client(dto.Name, dto.EMail, dto.PhoneNumber);
            clientRepository.AddAsync(client);
            clientRepository.Save();
            return Created(nameof(Get), client);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            clientRepository.Delete(id);
            clientRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreateClientDto dto)
        {
            var client = await clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            client.PhoneNumber = dto.PhoneNumber;
            client.Name = dto.Name;
            client.EMail = dto.EMail;
            clientRepository.Update(client);
            clientRepository.Save();
            return NoContent();
        }

    }
}
