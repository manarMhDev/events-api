using Events.Application.EventPlaces.Commands.CreatePlace;
using Events.Application.EventPlaces.Queries.GetPlaces;
using Events.Contracts.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Events.Application.EventPlaces.Commands.CreatePlace.CreateEventPlace;
using static Events.Application.EventPlaces.Queries.GetPlaces.GetEventPlaces;

namespace Events.Api.Controllers
{
    [ApiController]
    [Route("event-place")]
    [Authorize]
    public class EventPlaceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventPlaceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-one")]
        public async Task<Response<bool>> CreateEventPlace([FromForm]EventPlaceCreate request)
        {
            var result = await _mediator.Send(new CreateEventPlace(request));
            return result;
        }
        [HttpGet("get-all")]
        public async Task<Response<List<EventPlaceDto>>> GetAll()
        {
            var result = await _mediator.Send(new GetEventPlaces());
            return result;
        }
    }
}
