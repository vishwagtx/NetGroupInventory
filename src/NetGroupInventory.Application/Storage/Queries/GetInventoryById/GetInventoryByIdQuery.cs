using MediatR;
using NetGroupInventory.Application.Storage.Queries.Dtos;

namespace NetGroupInventory.Application.Storage.Queries.GetInventoryById
{
    public class GetInventoryByIdQuery : IRequest<ViewInventoryDto>
    {
        public int Id { get; set; }
    }
}
