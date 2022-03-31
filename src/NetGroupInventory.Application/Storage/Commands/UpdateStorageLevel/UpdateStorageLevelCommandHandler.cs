using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Storage.Commands.UpdateStorageLevel
{
    public class UpdateStorageLevelCommandHandler : BaseRequestHandler, IRequestHandler<UpdateStorageLevelCommand, ResponseDto>
    {
        public UpdateStorageLevelCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ResponseDto> Handle(UpdateStorageLevelCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (uow.StorageLevels.HasLevel(request.Level, identity.Identifier, request.Id))
                return new ResponseDto
                {
                    Succeed = false,
                    Errors = new List<string> { "Storage level is already existing in the database" }
                };

            StorageLevel level = await uow.StorageLevels.GetById(request.Id);

            level.Level = request.Level;
            level.Description = request.Description;
            level.ModifiedBy = identity.Identifier;
            level.ModifiedDateTime = DateTimeOffset.Now;

            await uow.SaveAsync();

            return new ResponseDto
            {
                Succeed = true,
            };
        }
    }
}
