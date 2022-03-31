using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application.Items.Queries.GetItemsForUser
{
    public class GetItemsForUserQueryHandler : BaseRequestHandler, IRequestHandler<GetItemsForUserQuery, IList<ViewItemDto>>
    {
        public GetItemsForUserQueryHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<IList<ViewItemDto>> Handle(GetItemsForUserQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var items = string.IsNullOrEmpty(request.Keyword) ? (await uow.Items.GetByUserId(identity.Identifier)) :
                (await uow.Items.GetByKeywordAndUserId(request.Keyword, identity.Identifier));

            return items.Select(s => new ViewItemDto
            {
                Id = s.Id,
                CategoryId = s.CategoryId,
                Category =  s.ItemCategory.Category,
                Title = s.Title,
                ImageUrl = s.ImageUrl,
                Description = s.Description,
                CreatedDateTime = s.CreatedDateTime,
                ModifiedDateTime = s.ModifiedDateTime
            }).ToList();
        }
    }
}
