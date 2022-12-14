using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;
using MyVetAppointment.API.Validators;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepository;
        private readonly IMapper mapper;
        private readonly AppointmentValidator _validator = new AppointmentValidator();

        public AppointmentsController(IAppointmentRepository appointmentRepository, IMapper mapper)
        {
            this.appointmentRepository = appointmentRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await appointmentRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var appointment = await appointmentRepository.GetByIdAsync(id);

            if (appointment != null)
            {
                return Ok(appointment);
                
            }
            return NotFound();
        }

        [HttpPost("{idPet:guid}/{idCabinet:guid}")]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto, Guid idPet, Guid idCabinet)
        {
            var appointment = mapper.Map<Appointment>(dto);

            appointment.attachPet(idPet);
            appointment.attachCabinet(idCabinet);
            var validationResult = await _validator.ValidateAsync(appointment);
            if (validationResult.Errors.Count > 0)
                return BadRequest(validationResult.Errors);
            else
            {
                await appointmentRepository.AddAsync(appointment);

                appointmentRepository.Save();
                return Created(nameof(Get), appointment);
            }
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            appointmentRepository.Delete(id);

            appointmentRepository.Save();
            return NoContent();
        }
    }
}
