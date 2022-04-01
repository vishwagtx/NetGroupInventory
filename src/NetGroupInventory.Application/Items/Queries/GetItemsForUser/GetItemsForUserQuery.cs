using MediatR;
using NetGroupInventory.Application.Items.Queries.Dtos;

namespace NetGroupInventory.Application.Items.Queries.GetItemsForUser
{
    public class GetItemsForUserQuery : IRequest<IList<ViewItemDto>>
    {
        public string Keyword { get; set; }
    }
}
