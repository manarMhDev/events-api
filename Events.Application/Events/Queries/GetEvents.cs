

using Events.Application.Common.Interfaces.Authentication;
using Events.Contracts.Dtos;
using Events.Contracts.Extensions;
using Events.Contracts.Wrappers;
using Events.Domain.Entities;
using Events.Domain.Enums;
using Events.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using static Events.Application.PersonType.Queries.GetEvents;

namespace Events.Application.PersonType.Queries
{
    public class GetEvents : IRequest<Response<PagedResult<GetEventsDto>>>
    {
        private readonly PagintationRequest _pagintationRequest;
        public GetEvents(PagintationRequest pagintationRequest)
        {
            _pagintationRequest = pagintationRequest;
        }
        public class GetEventsHandler : BaseHandler, IRequestHandler<GetEvents, Response<PagedResult<GetEventsDto>>>
        {
            public GetEventsHandler(IUnitOfWork iUnitOfWork, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
            }

            public async Task<Response<PagedResult<GetEventsDto>>> Handle(GetEvents request, CancellationToken cancellationToken)
            {
                var result = _unitOfWork.EventRepository.SearchFor().Select(item =>
             new GetEventsDto
             {
                 Id = item.Id,
                 Name = item.Name,
                 Language = item.Language,
             }) .ToQueryResult(request._pagintationRequest.PageNumber, request._pagintationRequest.PageSize);
                return new Response<PagedResult<GetEventsDto>>(result, true);
            }
        }
        public class GetEventsDto
        {
            public int Id { get;  set; }
            public string Name { get;  set; }
            public Language Language { get;  set; }
        }
    }
}
