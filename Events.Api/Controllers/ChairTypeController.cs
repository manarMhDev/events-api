using Events.Application.ChairTypes.Commands;
using Events.Application.ChairTypes.Queries;
using Events.Contracts.Dtos;
using Events.Contracts.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Events.Application.ChairTypes.Commands.CreateChairType;
using static Events.Application.ChairTypes.Queries.GetChairTypes;

namespace Events.Api.Controllers
{
    [ApiController]
    [Route("chair-types")]
    [Authorize]
    public class ChairTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ChairTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("create-one")]
        public async Task<Response<bool>> CreateChairType([FromForm] CreateChairTypeDto request)
        {
            var result = await _mediator.Send(new CreateChairType(request));
            return result;
        }
        [HttpGet("get-all")]
        public async Task<Response<PagedResult<GetChairTypeDto>>> GetAll(PagintationRequest request)
        {
            var result = await _mediator.Send(new GetChairTypes(request));
            return result;
        }
    }
}
