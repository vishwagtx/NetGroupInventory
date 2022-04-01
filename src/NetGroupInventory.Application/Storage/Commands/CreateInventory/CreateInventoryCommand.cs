using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Storage.Commands.Dtos;

namespace NetGroupInventory.Application.Storage.Commands.CreateInventory
{
    public class CreateInventoryCommand: BaseInventoryDto, IRequest<ResponseDto<int>>
    {
    }
}
