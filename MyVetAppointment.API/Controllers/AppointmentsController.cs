using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Response;
using MyVetAppointment.Application.Queries;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/v{version:apiVersion}/appointments")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IMediator mediator;

        public AppointmentsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<AppointmentResponse>> Get()
        {
            return await mediator.Send(new GetAllAppointmentsQuery());
        }

        [HttpGet("{id}")]
        public async Task<AppointmentResponse> Get(Guid id)
        {
            return await mediator.Send(new GetAppointmentByIdQuery() { Id = id });
        }

        [HttpPost("{idPet:guid}/{idCabinet:guid}")]
        public async Task<ActionResult<AppointmentResponse>> Create(Guid idPet, Guid idCabinet,
            [FromBody] CreateAppointmentCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AppointmentResponse>> Remove(Guid id)
        {
            var result = await mediator.Send(new DeleteAppointmentByIdCommand() { Id = id });
            return Ok(result);
        }
    }
}





























