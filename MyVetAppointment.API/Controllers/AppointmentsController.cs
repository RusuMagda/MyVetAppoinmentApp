using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVetAppoinment.Domain.Entities;
using MyVetAppoinment.Repositories;
using MyVetAppointment.API.DTOs;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepository appointmentRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository)
        {
            this.appointmentRepository = appointmentRepository;
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
            var appointment = new Appointment(dto.StartTime, dto.EndTime, dto.Description);

            appointment.attachPet(idPet);
            appointment.attachCabinet(idCabinet);

            await appointmentRepository.AddAsync(appointment);

            appointmentRepository.Save();
            return Created(nameof(Get), appointment);
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
