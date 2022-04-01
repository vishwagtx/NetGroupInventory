using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Storage.Commands.CreateInventory
{
    public class CreateInventoryCommandHandler : BaseRequestHandler, IRequestHandler<CreateInventoryCommand, ResponseDto<int>>
    {
        public CreateInventoryCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ResponseDto<int>> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Inventory inventory = new()
            {
                StorageLevelId = request.StorageLevelId,
                ItemId = request.ItemId,
                SerialNumber = request.SerialNumber,
                Quantity = request.Quantity,
                Note = request.Note,
                CreatedBy = identity.Identifier,
                CreatedDateTime = DateTimeOffset.Now,
            };

            uow.Inventories.Create(inventory);

            await uow.SaveAsync();

            return new ResponseDto<int>
            {
                Succeed = true,
                Id = inventory.Id
            };
        }
    }
}
