using MediatR;
using NetGroupInventory.Application.Common.Dtos;

namespace NetGroupInventory.Application.Items.Commands.CreateItem
{
    public class CreateItemCommand : BaseItemDto, IRequest<ResponseDto<int>>
    {
    }
}
