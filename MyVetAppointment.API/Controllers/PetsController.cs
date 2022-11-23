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
        public IActionResult Get()
        {
            return Ok(petRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(petRepository.Get(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePetDto dto)
        {
            var pet = new Pet(dto.OwnerId, dto.Name, dto.Birthdate);
            petRepository.Add(pet);
            petRepository.Save();
            return Created(nameof(Get), pet);
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
