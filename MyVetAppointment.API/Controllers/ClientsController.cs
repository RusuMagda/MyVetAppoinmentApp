using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Domain.Entities;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.API.Validators;
using MyVetAppointment.Infrastructure.Repositories;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/v{version:apiVersion}/clients")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ClientsController : ControllerBase
    {
        private readonly  IClientRepository clientRepository;
  
        private readonly IMapper mapper;

      


        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;

       
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
        [HttpGet("{email}")]
        public IActionResult GetEmail(string email)
        {
            var client =  clientRepository.GetByEmail(email);
           
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
            var client = mapper.Map<Client>(dto);

           
                await clientRepository.AddAsync(client);
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
            mapper.Map(dto, client);
            clientRepository.Update(client);
            clientRepository.Save();
            return NoContent();
        }

    }
}
