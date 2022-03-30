using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application
{
    public abstract class BaseRequestHandler
    {
        protected readonly IUnitOfWork uow = null;
        protected readonly IUserIdentity identity = null;

        public BaseRequestHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public BaseRequestHandler(IUnitOfWork uow,
            IUserIdentity identity)
        {
            this.uow = uow;
            this.identity = identity;
        }
    }
}
