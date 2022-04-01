using MediatR;

namespace NetGroupInventory.Application.Storage.Commands.DeleteInventory
{
    public class DeleteInventoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
