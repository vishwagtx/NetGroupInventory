using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Storage.Commands.CreateStorageLevel
{
    public class CreateStorageLevelCommandHandler : BaseRequestHandler, IRequestHandler<CreateStorageLevelCommand, ResponseDto<int>>
    {
        public CreateStorageLevelCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ResponseDto<int>> Handle(CreateStorageLevelCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (uow.StorageLevels.HasLevel(request.Level, identity.Identifier))
                return new ResponseDto<int>
                {
                    Succeed = false,
                    Errors = new List<string> { "Storage level is already existing in the database" }
                };

            StorageLevel level = new()
            {
                Level = request.Level,
                Description = request.Description,
                CreatedBy = identity.Identifier,
                CreatedDateTime = DateTimeOffset.Now,
            };

            uow.StorageLevels.Create(level);

            await uow.SaveAsync();

            return new ResponseDto<int>
            {
                Succeed = true,
                Id = level.Id
            };
        }
    }
}
