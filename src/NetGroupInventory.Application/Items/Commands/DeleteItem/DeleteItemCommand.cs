using MediatR;

namespace NetGroupInventory.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest
    {
        public int Id { get; set; }
    }
}
