using MediatR;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Application.Interfaces.Rest;

namespace NetGroupInventory.Application.Statistics.GetStatistic
{
    public class GetStatisticQueryHandler : BaseRequestHandler, IRequestHandler<GetStatisticQuery, StatisticReponseDto>
    {
        readonly IIdentityServerClient identityServerClient;

        public GetStatisticQueryHandler(IUnitOfWork uow,
            IIdentityServerClient identityServerClient) : base(uow)
        {
            this.identityServerClient = identityServerClient;
        }

        public async Task<StatisticReponseDto> Handle(GetStatisticQuery request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var users = await identityServerClient.GetUsers();

            var storageLevels = await uow.StorageLevels.GetUserWiseCount();
            var items = await uow.Items.GetUserWiseCount();
            var inventorytItems = await uow.Inventories.GetUserWiseCount();
            var userActivities = await uow.Activities.GetLatestUserActivity();

            var userStatistics = users.Select(s => new UserStatisticDto {
                UserId = s.Id,
                UserName = s.UserName,
                Name = s.Name,
                StorageLevelCount = storageLevels.FirstOrDefault(x => x.Key.ToString() == s.Id)?.Count ?? 0,
                ItemCount = items.FirstOrDefault(x => x.Key.ToString() == s.Id)?.Count ?? 0,
                InventoryCount = inventorytItems.FirstOrDefault(x => x.Key.ToString() == s.Id)?.Count ?? 0
            }).ToList();

            var lastActiveUsers = userActivities.Select(s => {
                var user = users.FirstOrDefault(f => f.Id == s.UserId);

                return new LastActiveUser
                {
                    UserId = s.UserId,
                    Name = user?.Name,
                    UserName = user?.UserName,
                    LastActiveDateTime = s.LastActivityDateTime
                };
            }).ToList();

            return new StatisticReponseDto
            {
                UserStatistics = userStatistics,
                LastActiveUsers = lastActiveUsers,
            };
        }
    }
}
