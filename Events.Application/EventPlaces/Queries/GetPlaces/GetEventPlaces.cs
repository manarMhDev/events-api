

using Events.Application.Common.Interfaces.Authentication;
using Events.Contracts.Wrappers;
using Events.Domain.Entities;
using Events.Domain.Enums;
using Events.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using static Events.Application.EventPlaces.Queries.GetPlaces.GetEventPlaces;

namespace Events.Application.EventPlaces.Queries.GetPlaces
{
    public class GetEventPlaces : IRequest<Response<List<EventPlaceDto>>>
    {
        public GetEventPlaces()
        {

        }
        public class GetEventPlacesHandler : BaseHandler, IRequestHandler<GetEventPlaces, Response<List<EventPlaceDto>>>
        {
            public GetEventPlacesHandler(IUnitOfWork iUnitOfWork, IJwtTokenGenerator jwtTokenGenerator, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
            }

            public async Task<Response<List<EventPlaceDto>>> Handle(GetEventPlaces request, CancellationToken cancellationToken)
            {
               var result =  _unitOfWork.EventPlaceRepository.SearchFor().Select(item => 
                new EventPlaceDto
                {
                     Id = item.Id,
                      Name = item.Name,
                       Language = item.Language,
                        SeatingChartImagePath = item.SeatingChartImagePath,
                         Columns = item.Columns,
                          Rows = item.Rows,
                           SeatingChart = item.SeatingChart
                }).ToList();
                return result;
            }
        }
        public class EventPlaceDto
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Language Language { get; set; }
            public SeatingChart SeatingChart { get; set; }
            public string SeatingChartImagePath { get; set; }
            public int? Columns { get; set; }
            public int? Rows { get; set; }
        }

    }
}
