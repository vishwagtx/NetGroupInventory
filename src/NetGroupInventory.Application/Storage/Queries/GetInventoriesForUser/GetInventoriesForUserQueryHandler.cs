using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Storage.Queries.Dtos;

namespace NetGroupInventory.Application.Storage.Queries.GetInventoriesForUser
{
    public class GetInventoriesForUserQueryHandler : BaseRequestHandler, IRequestHandler<GetInventoriesForUserQuery, IList<ViewInventoryDto>>
    {
        public GetInventoriesForUserQueryHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<IList<ViewInventoryDto>> Handle(GetInventoriesForUserQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var items = string.IsNullOrEmpty(request.Keyword) ? (await uow.Inventories.GetByUserId(identity.Identifier)) :
                (await uow.Inventories.GetByKeywordAndUserId(request.Keyword, identity.Identifier));

            return items.Select(s => new ViewInventoryDto
            {
                Id = s.Id,
                StorageLevelId = s.StorageLevelId,
                StorageLevel = s.StorageLevel.Level,
                ItemId = s.ItemId,
                Item = new ItemDto
                {
                    Id = s.ItemId,
                    CategoryId = s.Item.CategoryId,
                    Description = s.Item.Description,
                    ImageUrl = s.Item.ImageUrl,
                    Title = s.Item.Title,
                    Category = s.Item.ItemCategory.Category
                },
                Note = s.Note,
                Quantity = s.Quantity,
                SerialNumber = s.SerialNumber,
                CreatedDateTime = s.CreatedDateTime,
                ModifiedDateTime = s.ModifiedDateTime,
            }).ToList();
        }
    }
}
