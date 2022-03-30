using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Stoarge.Commands.CreateStoargeLevel
{
    public class CreateStoargeLevelCommandHandler : BaseRequestHandler, IRequestHandler<CreateStoargeLevelCommand, ResponseDto>
    {
        public CreateStoargeLevelCommandHandler(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<ResponseDto> Handle(CreateStoargeLevelCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (uow.StoargeLevels.HasLevel(request.Level))
                return new ResponseDto
                {
                    Succeed = false,
                    Errors = new List<string> { "Storage level is already existing in the database" }
                };

            StoargeLevel level = new()
            {
                Level = request.Level,
                Description = request.Description,
                CreatedBy = "test",
                CreatedDateTime = DateTimeOffset.Now,
            };

            uow.StoargeLevels.Create(level);

            await uow.SaveAsync();

            return new ResponseDto
            {
                Succeed = true
            };
        }
    }
}
