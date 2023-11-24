﻿

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
using static Events.Application.PersonType.Queries.GetPersonType;

namespace Events.Application.PersonType.Queries
{
    public class GetPersonType : IRequest<Response<PagedResult<GetPersonTypeDto>>>
    {
        private readonly PagintationRequest _pagintationRequest;
        public GetPersonType(PagintationRequest pagintationRequest)
        {
            _pagintationRequest = pagintationRequest;
        }
        public class GetPersonTypeHandler : BaseHandler, IRequestHandler<GetPersonType, Response<PagedResult<GetPersonTypeDto>>>
        {
            public GetPersonTypeHandler(IUnitOfWork iUnitOfWork, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
            }

            public async Task<Response<PagedResult<GetPersonTypeDto>>> Handle(GetPersonType request, CancellationToken cancellationToken)
            {
                var result = _unitOfWork.PersonTypeRepository.SearchFor().Select(item =>
             new GetPersonTypeDto
             {
                 Id = item.Id,
                 Name = item.Name,
                 Language = item.Language,
             }) .ToQueryResult(request._pagintationRequest.PageNumber, request._pagintationRequest.PageSize);
                return new Response<PagedResult<GetPersonTypeDto>>(result, true);
            }
        }
        public class GetPersonTypeDto
        {
            public int Id { get;  set; }
            public string Name { get;  set; }
            public Language Language { get;  set; }
            public string Color { get;  set; }
        }
    }
}
