using MediatR;

namespace NetGroupInventory.Application.Storage.Queries.GetStorageLevelsForUser
{
    public class GetStorageLevelsForUserQuery: IRequest<IList<ViewStorageLevelDto>>
    {
        public string Keyword { get; set; }
    }
}
