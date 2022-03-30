using MediatR;
using NetGroupInventory.Application.Stoarge.Commands.CreateStoargeLevel;

namespace NetGroupInventory.Service.MediatR
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStoargeLevelCommandHandler));
        }
    }
}
