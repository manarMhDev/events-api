
using Events.Application.PersonType.Commands;
using Events.Application.PersonType.Queries;
using Events.Application.PersonType.Commands;
using Events.Application.PersonType.Queries;
using Events.Contracts.Dtos;
using Events.Contracts.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Events.Application.PersonType.Commands.CreatePersonType;
using static Events.Application.PersonType.Queries.GetPersonType;
using static Events.Application.PersonType.Queries.GetPersonTypeById;
using static Events.Application.PersonType.Commands.UpdatePersonType;

namespace Events.Api.Controllers
{
    [ApiController]
    [Route("person-type")]
    [Authorize]
    public class PersonTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-one")]
        public async Task<Response<bool>> CreatePersonType(CreatePersonTypeDto request)
        {
            var result = await _mediator.Send(new CreatePersonType(request));
            return result;
        }
        [HttpGet("get-all")]
        public async Task<Response<PagedResult<GetPersonTypeDto>>> GetPersonTypes(PagintationRequest request)
        {
            var result = await _mediator.Send(new GetPersonType(request));
            return result;
        }
        [HttpGet("get-one")]
        public async Task<Response<PersonTypeDto>> GetPersonTypeById(int id)
        {
            var result = await _mediator.Send(new GetPersonTypeById(id));
            return result;
        }
        [HttpPatch("edit-one")]
        public async Task<Response<bool>> UpdatePersonType(UpdatePersonTypeDto request)
        {
            var result = await _mediator.Send(new UpdatePersonType(request));
            return result;
        }
        [HttpDelete("delete-one")]
        public async Task<Response<bool>> DeletePersonType(int id)
        {
            var result = await _mediator.Send(new DeletePersonType(id));
            return result;
        }
    }
}
