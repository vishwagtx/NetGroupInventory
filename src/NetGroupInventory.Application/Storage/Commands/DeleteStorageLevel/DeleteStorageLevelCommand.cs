using MediatR;

namespace NetGroupInventory.Application.Storage.Commands.DeleteStorageLevel
{
    public class DeleteStorageLevelCommand : IRequest
    {
        public int Id { get; set; }
    }
}
