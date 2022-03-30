using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Stoarge.Commands.Dtos;

namespace NetGroupInventory.Application.Stoarge.Commands.CreateStoargeLevel
{
    public class CreateStoargeLevelCommand : BaseStoargeLevelDto, IRequest<ResponseDto<int>>
    {
    }
}
