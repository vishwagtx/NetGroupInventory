using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Storage.Commands.Dtos;

namespace NetGroupInventory.Application.Storage.Commands.UpdateInventory
{
    public class UpdateInventoryCommand : BaseInventoryDto, IRequest<ResponseDto>
    {
        public int Id { get; set; }
    }
}
