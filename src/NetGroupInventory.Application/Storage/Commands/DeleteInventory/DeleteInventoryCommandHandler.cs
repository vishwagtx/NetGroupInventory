using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application.Storage.Commands.DeleteInventory
{
    public class DeleteInventoryCommandHandler : BaseRequestHandler, IRequestHandler<DeleteInventoryCommand>
    {
        public DeleteInventoryCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<Unit> Handle(DeleteInventoryCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await uow.Inventories.Delete(request.Id);

            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}
