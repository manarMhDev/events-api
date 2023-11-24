
using Events.Application.PersonType.Commands;
using Events.Application.PersonType.Queries;
using Events.Application.TitleSecond.Commands;
using Events.Application.TitleSecond.Queries;
using Events.Contracts.Dtos;
using Events.Contracts.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Events.Application.PersonType.Commands.CreateEvent;
using static Events.Application.PersonType.Queries.GetEvents;
using static Events.Application.TitleSecond.Commands.CreateTitleSecond;
using static Events.Application.TitleSecond.Queries.GetTitleSecond;

namespace Events.Api.Controllers
{
    [ApiController]
    [Route("events")]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-one")]
        public async Task<Response<bool>> CreateEvent(CreateEventDto request)
        {
            var result = await _mediator.Send(new CreateEvent(request));
            return result;
        }
        [HttpGet("get-all")]
        public async Task<Response<PagedResult<GetEventsDto>>> GetEvent(PagintationRequest request)
        {
            var result = await _mediator.Send(new GetEvents(request));
            return result;
        }
    }
}
