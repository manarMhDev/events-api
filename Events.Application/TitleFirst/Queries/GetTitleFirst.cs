

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
using static Events.Application.TitleFirst.Queries.GetTitleFirst;

namespace Events.Application.TitleFirst.Queries
{
    public class GetTitleFirst : IRequest<Response<PagedResult<GetTitleFirstDto>>>
    {
        private readonly int _page;
        private readonly int _size;
        public GetTitleFirst(int page,int size)
        {
            _page = page;
            _size = size;
        }
        public class GetTitleFirstHandler : BaseHandler, IRequestHandler<GetTitleFirst, Response<PagedResult<GetTitleFirstDto>>>
        {
            public GetTitleFirstHandler(IUnitOfWork iUnitOfWork, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
            }

            public async Task<Response<PagedResult<GetTitleFirstDto>>> Handle(GetTitleFirst request, CancellationToken cancellationToken)
            {
                var result = _unitOfWork.TitleFirstRepository.SearchFor().Select(item =>
             new GetTitleFirstDto
             {
                 Id = item.Id,
                 Name = item.Name,
                 Language = item.Language,
             }) .ToQueryResult(request._page, request._size);
                return new Response<PagedResult<GetTitleFirstDto>>(result, true);
            }
        }
        public class GetTitleFirstDto
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
