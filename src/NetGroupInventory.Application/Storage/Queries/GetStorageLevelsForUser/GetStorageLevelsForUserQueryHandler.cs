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

            var levels = string.IsNullOrEmpty(request.Keyword) ? (await uow.StorageLevels.GetByUserId(identity.Identifier)) :
                (await uow.StorageLevels.GetByKeywordAndUserId(request.Keyword, identity.Identifier));

            return levels.Select(s => new ViewStorageLevelDto
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
