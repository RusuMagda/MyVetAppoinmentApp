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
        public async Task<IActionResult> Get()
        {
            return Ok(await clientRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var client = await clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpGet("{id:guid}/pets")]
        public async Task<IActionResult> GetPets(Guid id)
        {
            var client = await clientRepository.GetByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            var pets = await clientRepository.GetAllPetsAsync(id);
            return Ok(pets);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientDto dto)
        {
            var client = new Client(dto.Name, dto.EMail, dto.PhoneNumber);
            await clientRepository.AddAsync(client);
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

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreateClientDto dto)
        {
            var client = clientRepository.Get(id);
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
