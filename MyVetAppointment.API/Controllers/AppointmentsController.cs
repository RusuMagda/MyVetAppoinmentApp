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
        private readonly IPetRepository petRepository;
        private readonly ICabinetRepository cabinetRepository;

        public AppointmentsController(IAppointmentRepository appointmentRepository, IPetRepository petRepository, ICabinetRepository cabinetRepository)
        {
            this.appointmentRepository = appointmentRepository;
            this.petRepository = petRepository;
            this.cabinetRepository = cabinetRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(appointmentRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var appointment = appointmentRepository.GetByIdAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }

        [HttpPost("{idPet:guid}/{idCabinet:guid}")]
        public IActionResult Create([FromBody] CreateAppointmentDto dto, Guid idPet, Guid idCabinet)
        {
            var appointment = new Appointment(dto.StartTime, dto.EndTime, dto.Description);

            appointment.attachPet(idPet);
            appointment.attachCabinet(idCabinet);

            appointmentRepository.AddAsync(appointment);
            appointmentRepository.Save();

            return Created(nameof(Get), appointment);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
           // var appointment = appointmentRepository.GetAsync(id);
            appointmentRepository.Delete(id);
            appointmentRepository.Save();
            return NoContent();
        }
    }
}
