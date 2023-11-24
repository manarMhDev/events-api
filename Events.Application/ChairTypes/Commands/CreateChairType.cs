

using Events.Application.Common.Interfaces.Authentication;
using Events.Contracts.Services.Interfaces;
using Events.Contracts.Wrappers;
using Events.Domain.Entities;
using Events.Domain.Enums;
using Events.Infrastructure.UnitOfWork;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Events.Application.ChairTypes.Commands
{
    public class CreateChairType : IRequest<Response<bool>>
    {
        private readonly CreateChairTypeDto _createChairTypeDto;
        public CreateChairType(CreateChairTypeDto createChairTypeDto)
        {

            _createChairTypeDto = createChairTypeDto;

        }
        public class CreateChairTypeHandler : BaseHandler, IRequestHandler<CreateChairType, Response<bool>>
        {
            private readonly IFileService _documentService;
            public CreateChairTypeHandler(IUnitOfWork iUnitOfWork, 
                IJwtTokenGenerator jwtTokenGenerator, 
                UserManager<ApplicationUser> userManager,
                IHttpContextAccessor httpContextAccessor,
                IFileService documentService) : base(iUnitOfWork, jwtTokenGenerator, userManager, httpContextAccessor)
            {
                _documentService = documentService;
            }

            public async Task<Response<bool>> Handle(CreateChairType request, CancellationToken cancellationToken)
            {
                var result = await _documentService.UploadFile(new Contracts.Dtos.UploadFileModel
                {
                    FormFile = request._createChairTypeDto.ChairImage,
                    FolderPrefix = Contracts.Enums.FolderType.ChairTypes
                });
                var chairType = new ChairType(
                      request._createChairTypeDto.Name,
                      request._createChairTypeDto.Language,
                      request._createChairTypeDto.Color,
                      request._createChairTypeDto.ColorText,
                      result);
                _unitOfWork.ChairTypeRepository.Insert(chairType);

                return await _unitOfWork.CommitAsync();
            }
        }
        public class CreateChairTypeDto
        {
            public string Name { get; set; }
            public string Color { get; set; }
            public string ColorText { get; set; }
            public Language Language { get; set; }
            public IFormFile ChairImage { get; set; }
        }
    }
}
