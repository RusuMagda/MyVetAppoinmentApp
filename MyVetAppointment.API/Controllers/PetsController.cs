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
            return Ok(petRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(petRepository.GetByIdAsync(id));
        }

        [HttpGet("{id}/appointments")]
        public IActionResult GetAppointments(Guid id)
        {
            var pets = petRepository.GetAppointmentsAsync(id);
            return Ok(pets);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePetDto dto)
        {
            var pet = new Pet(dto.OwnerId, dto.Name, dto.Birthdate);
            petRepository.AddAsync(pet);
            petRepository.Save();
            return Created(nameof(Get), pet);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            petRepository.Delete(id);
            petRepository.Save();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] CreatePetDto dto)
        {
            var pet = new Pet(id, dto.OwnerId, dto.Name, dto.Birthdate);
            petRepository.Update(pet);
            petRepository.Save();
            return NoContent();
        }
    }
}
