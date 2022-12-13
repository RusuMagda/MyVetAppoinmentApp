using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository petRepository;
        private readonly IMapper mapper;

        public PetsController(IPetRepository petRepository, IMapper mapper)
        {
            this.petRepository = petRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await petRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await petRepository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}/appointments")]
        public async Task<IActionResult> GetAppointmentsAsync(Guid id)
        {
            var pets = await petRepository.GetAppointmentsAsync(id);
            return Ok(pets);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreatePetDto dto)
        {
            var pet = mapper.Map<Pet>(dto);
            await petRepository.AddAsync(pet);
            petRepository.Save();
            return Created(nameof(GetAsync), pet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveAsync(Guid id)
        {
            var pet = await petRepository.GetByIdAsync(id);
            if(pet == null)
            {
                return NotFound();
            }
            petRepository.Delete(id);
            petRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CreatePetDto dto)
        {
            var pet = await petRepository.GetByIdAsync(id);
            if(pet == null)
            {
                return NotFound();
            }

            mapper.Map(dto, pet);
            petRepository.Update(pet);
            petRepository.Save();
            return NoContent();
        }
    }
}
