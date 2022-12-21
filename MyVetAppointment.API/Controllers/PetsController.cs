using Microsoft.AspNetCore.Mvc;
using MediatR;
using MyVetAppointment.Application.Commands;
using MyVetAppointment.Application.Queries;
using MyVetAppointment.Application.Response;

namespace MyVetAppointment.API.Controllers
{
    [Route("api/v{version:apiVersion}/pets")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PetsController : ControllerBase
    {
        private readonly IMediator mediator;

        public PetsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]

        public async Task<List<PetResponse>> Get()
        {
            return await mediator.Send(new GetAllPetsQuery());
        }

        [HttpGet("{id}")]
        public async Task<PetResponse> Get(Guid id)
        {
            return await mediator.Send(new GetPetByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<PetResponse>> Create([FromBody] CreatePetCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id}/appointments")]
        public async Task<List<AppointmentResponse>> GetPetAppointments(Guid id)
        {
            return await mediator.Send(new GetPetAppointmentsQuery { Id = id });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PetResponse>> Remove(Guid id)
        {
            var result = await mediator.Send(new DeletePetByIdCommand { Id = id });
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PetResponse>> Update(Guid id, [FromBody] UpdatePetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{id:guid}/{name}")]
        public async Task<PetResponse> GetPetId(Guid id, String name)
        {
            return await mediator.Send(new GetPetIdQuery() { Id = id, Name = name });
        }

        [HttpGet("{id:guid}/pets")]
        public async Task<List<PetResponse>> GetPetsClient(Guid id)
        {
            return await mediator.Send(new GetPetsOfClientQuery { Id = id });
        }
    }
}
