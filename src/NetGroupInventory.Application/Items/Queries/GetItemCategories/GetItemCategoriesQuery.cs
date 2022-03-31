using MediatR;

namespace NetGroupInventory.Application.Items.Queries.GetItemCategories
{
    public class GetItemCategoriesQuery : IRequest<IList<ItemCategoryDto>>
    {
    }
}
