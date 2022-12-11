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
            return Ok(appointmentRepository.GetAll());
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var appointment = appointmentRepository.Get(id);
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
            var pet = petRepository.Get(idPet);
            var cabinet = cabinetRepository.Get(idCabinet);
            appointment.attachPet(pet);
            appointment.attachCabinet(cabinet);
            appointmentRepository.Add(appointment);
            appointmentRepository.Save();
            return Created(nameof(Get), appointment);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var appointment = appointmentRepository.Get(id);
            appointmentRepository.Delete(appointment);
            appointmentRepository.Save();
            return NoContent();
        }
    }
}
