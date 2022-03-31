using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Storage.Commands.Dtos;

namespace NetGroupInventory.Application.Storage.Commands.UpdateStorageLevel
{
    public class UpdateStorageLevelCommand : BaseStorageLevelDto, IRequest<ResponseDto>
    {
        public int Id { get; set; }
    }
}
