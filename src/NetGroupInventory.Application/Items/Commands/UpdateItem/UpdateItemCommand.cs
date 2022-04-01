using MediatR;
using NetGroupInventory.Application.Common.Dtos;

namespace NetGroupInventory.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommand: BaseItemDto, IRequest<ResponseDto>
    {
        public int Id { get; set; }
    }
}
