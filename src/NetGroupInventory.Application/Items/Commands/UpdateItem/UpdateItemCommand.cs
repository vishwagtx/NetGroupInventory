using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Items.Commands.Dtos;

namespace NetGroupInventory.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand: BaseItemDto, IRequest<ResponseDto>
    {
        public int Id { get; set; }
    }
}
