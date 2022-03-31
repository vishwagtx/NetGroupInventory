using MediatR;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application.Items.Queries.GetItemCategories
{
    public class GetItemCategoriesQueryHandler : BaseRequestHandler, IRequestHandler<GetItemCategoriesQuery, IList<ItemCategoryDto>>
    {
        public GetItemCategoriesQueryHandler(IUnitOfWork uow) : base(uow)
        {
        }

        public async Task<IList<ItemCategoryDto>> Handle(GetItemCategoriesQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return (await uow.ItemCategories.GetAll())
                .Select(c => new ItemCategoryDto { 
                    Id = c.Id,
                    Category = c.Category
                }).ToList();
        }
    }
}
