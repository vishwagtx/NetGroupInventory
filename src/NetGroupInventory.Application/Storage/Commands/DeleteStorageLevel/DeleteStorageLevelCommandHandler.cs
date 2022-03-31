using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application.Storage.Commands.DeleteStorageLevel
{
    public class DeleteStorageLevelCommandHandler : BaseRequestHandler, IRequestHandler<DeleteStorageLevelCommand>
    {
        public DeleteStorageLevelCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<Unit> Handle(DeleteStorageLevelCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await uow.StorageLevels.Delete(request.Id);

            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}
