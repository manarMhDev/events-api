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
using static Events.Application.TitleSecond.Queries.GetTitleSecond;

namespace Events.Application.TitleSecond.Queries
{
    public class GetTitleSecond : IRequest<Response<PagedResult<GetTitleSecondDto>>>
    {
        private readonly PagintationRequest _pagintationRequest;
        public GetTitleSecond(PagintationRequest pagintationRequest)
        {
            _pagintationRequest = pagintationRequest;
        }
        public class GetTitleSecondHandler : BaseHandler, IRequestHandler<GetTitleSecond, Response<PagedResult<GetTitleSecondDto>>>
        {
            public GetTitleSecondHandler(IUnitOfWork iUnitOfWork, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
            }

            public async Task<Response<PagedResult<GetTitleSecondDto>>> Handle(GetTitleSecond request, CancellationToken cancellationToken)
            {
                var result = _unitOfWork.TitleSecondRepository.SearchFor().Select(item =>
             new GetTitleSecondDto
             {
                 Id = item.Id,
                 Name = item.Name,
                 Language = item.Language,
             }) .ToQueryResult(request._pagintationRequest.PageNumber, request._pagintationRequest.PageSize);
                return new Response<PagedResult<GetTitleSecondDto>>(result, true);
            }
        }
        public class GetTitleSecondDto
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
