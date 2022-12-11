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

        public PetsController(IPetRepository petRepository)
        {
            this.petRepository = petRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await petRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            return Ok(await petRepository.GetByIdAsync(id));
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
            var pet = new Pet(dto.OwnerId, dto.Name, dto.Birthdate);
            await petRepository.AddAsync(pet);
            petRepository.Save();
            return Created(nameof(GetAsync), pet);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            var pet = petRepository.Get(id);
            if(pet == null)
            {
                return NotFound();
            }
            petRepository.Delete(pet);
            petRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreatePetDto dto)
        {
            var pet = petRepository.Get(id);
            if(pet == null)
            {
                return NotFound();
            }
            pet.Name = dto.Name;
            pet.OwnerId = dto.OwnerId;
            pet.Birthdate = dto.Birthdate;
            petRepository.Update(pet);
            petRepository.Save();
            return NoContent();
        }



    }
}
