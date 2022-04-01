using MediatR;
using NetGroupInventory.Application.Storage.Queries.Dtos;

namespace NetGroupInventory.Application.Storage.Queries.GetInventoriesForUser
{
    public class GetInventoriesForUserQuery : IRequest<IList<ViewInventoryDto>>
    {
        public string Keyword { get; set; }
    }
}
