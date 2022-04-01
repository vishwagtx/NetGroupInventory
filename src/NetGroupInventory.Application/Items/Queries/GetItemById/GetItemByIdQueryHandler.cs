using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Items.Queries.Dtos;

namespace NetGroupInventory.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : BaseRequestHandler, IRequestHandler<GetItemByIdQuery, ViewItemDto>
    {
        public GetItemByIdQueryHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ViewItemDto> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            var item = await uow.Items.GetByIdWithDetails(request.Id);

            if (item == null)
                return null;

            return new ViewItemDto
            {
                Id = item.Id,
                Title = item.Title,
                CategoryId = item.CategoryId,
                Description = item.Description,
                ImageUrl = item.ImageUrl,
                Category = item.ItemCategory.Category,
                CreatedDateTime = item.CreatedDateTime,
                ModifiedDateTime = item.ModifiedDateTime,
            };
        }
    }
}
