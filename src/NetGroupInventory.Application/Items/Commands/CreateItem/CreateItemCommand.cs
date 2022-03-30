using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Items.Commands.Dtos;

namespace NetGroupInventory.Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : BaseItemDto, IRequest<ResponseDto<int>>
    {
    }
}
