using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Storage.Commands.Dtos;

namespace NetGroupInventory.Application.Storage.Commands.CreateStorageLevel
{
    public class CreateStorageLevelCommand : BaseStorageLevelDto, IRequest<ResponseDto<int>>
    {
    }
}
