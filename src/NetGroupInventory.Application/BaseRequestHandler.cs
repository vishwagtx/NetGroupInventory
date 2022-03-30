using NetGroupInventory.Application.Interfaces;

namespace NetGroupInventory.Application
{
    public abstract class BaseRequestHandler
    {
        protected IUnitOfWork uow = null;

        public BaseRequestHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
