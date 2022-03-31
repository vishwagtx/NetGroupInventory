using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application.Storage.Queries.GetStorageLevelsForUser
{
    public class GetStorageLevelsForUserQueryHandler : BaseRequestHandler, IRequestHandler<GetStorageLevelsForUserQuery, IList<ViewStorageLevelDto>>
    {
        public GetStorageLevelsForUserQueryHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<IList<ViewStorageLevelDto>> Handle(GetStorageLevelsForUserQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            return (await uow.StorageLevels.GetByUserId(identity.Identifier))
            .Select(s => new ViewStorageLevelDto
            {
                Id = s.Id,
                Level = s.Level,
                Description = s.Description,
                CreatedDateTime = s.CreatedDateTime,
                ModifiedDateTime = s.ModifiedDateTime
            }).ToList();
        }
    }
}
