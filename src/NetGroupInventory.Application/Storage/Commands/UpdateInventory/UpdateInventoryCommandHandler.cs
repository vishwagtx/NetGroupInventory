using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Stoarge;

namespace NetGroupInventory.Application.Storage.Commands.UpdateInventory
{
    public class UpdateInventoryCommandHandler : BaseRequestHandler, IRequestHandler<UpdateInventoryCommand, ResponseDto>
    {
        public UpdateInventoryCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ResponseDto> Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
        {
            Inventory inventory = await uow.Inventories.GetById(request.Id);

            if (inventory == null) return new ResponseDto
            {
                Succeed = false
            };

            inventory.ItemId = request.ItemId;
            inventory.StorageLevelId = request.StorageLevelId;
            inventory.SerialNumber = request.SerialNumber;
            inventory.Quantity = request.Quantity;
            inventory.Note = request.Note;
            inventory.ModifiedBy = identity.Identifier;
            inventory.ModifiedDateTime = DateTimeOffset.Now;

            await uow.SaveAsync();

            return new ResponseDto
            {
                Succeed = true
            };
        }
    }
}
