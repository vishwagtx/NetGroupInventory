using MediatR;
using NetGroupInventory.Application.Items.Queries.Dtos;

namespace NetGroupInventory.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQuery : IRequest<ViewItemDto>
    {
        public int Id { get; set; }
    }
}
