using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Storage.Queries.Dtos;
using NetGroupInventory.Application.Storage.Queries.GetInventoryById;

namespace NetGroupInventory.Application.Storage.Querieinventory.GetInventoryById
{
    public class GetInventoryByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetInventoryByIdQuery, ViewInventoryDto>
    {
        public GetInventoryByIdQueryHandler(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<ViewInventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await uow.Inventories.GetByIdWithDetail(request.Id);

            if (inventory == null) return null;

            return new ViewInventoryDto
            {
                Id = inventory.Id,
                StorageLevelId = inventory.StorageLevelId,
                StorageLevel = inventory.StorageLevel.Level,
                ItemId = inventory.ItemId,
                Item = new ItemDto
                {
                    Id = inventory.ItemId,
                    CategoryId = inventory.Item.CategoryId,
                    Description = inventory.Item.Description,
                    ImageUrl = inventory.Item.ImageUrl,
                    Title = inventory.Item.Title,
                    Category = inventory.Item.ItemCategory.Category
                },
                Note = inventory.Note,
                Quantity = inventory.Quantity,
                SerialNumber = inventory.SerialNumber,
                CreatedDateTime = inventory.CreatedDateTime,
            };
        }
    }
}
