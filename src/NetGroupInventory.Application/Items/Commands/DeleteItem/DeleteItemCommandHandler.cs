using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : BaseRequestHandler, IRequestHandler<DeleteItemCommand>
    {
        public DeleteItemCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            await uow.Items.Delete(request.Id);

            await uow.SaveAsync();

            return Unit.Value;
        }
    }
}
