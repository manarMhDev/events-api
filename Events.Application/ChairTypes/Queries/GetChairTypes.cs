

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
using static Events.Application.ChairTypes.Queries.GetChairTypes;

namespace Events.Application.ChairTypes.Queries
{
    public class GetChairTypes : IRequest<Response<PagedResult<GetChairTypeDto>>>
    {
        private readonly PagintationRequest _pagintationRequest;
        public GetChairTypes(PagintationRequest pagintationRequest)
        {
            _pagintationRequest = pagintationRequest;
        }
        public class GetChairTypesHandler : BaseHandler, IRequestHandler<GetChairTypes, Response<PagedResult<GetChairTypeDto>>>
        {
            public GetChairTypesHandler(IUnitOfWork iUnitOfWork, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
            }

            public async Task<Response<PagedResult<GetChairTypeDto>>> Handle(GetChairTypes request, CancellationToken cancellationToken)
            {
                var result = _unitOfWork.ChairTypeRepository.SearchFor().Select(item =>
             new GetChairTypeDto
             {
                 Id = item.Id,
                 Name = item.Name,
                 Language = item.Language,
                 Color = item.Color,
                 ColorText = item.ColorText,
                 ImagePath = item.ImagePath
             }) .ToQueryResult(request._pagintationRequest.PageNumber, request._pagintationRequest.PageSize);
                return new Response<PagedResult<GetChairTypeDto>>(result, true);
            }
        }
        public class GetChairTypeDto
        {
            public int Id { get;  set; }
            public string Name { get;  set; }
            public Language Language { get;  set; }
            public string Color { get;  set; }
            public string ColorText { get;  set; }
            public string ImagePath { get;  set; }
        }
    }
}
