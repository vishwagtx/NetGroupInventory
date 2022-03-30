using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Application.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler : BaseRequestHandler, IRequestHandler<CreateItemCommand, ResponseDto<int>>
    {
        public CreateItemCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ResponseDto<int>> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (uow.Items.HasTitle(request.Title))
                return new ResponseDto<int>
                {
                    Succeed = false,
                    Errors = new List<string> { "Item is already existing in the database" }
                };

            Item item = new()
            {
                Title = request.Title,
                Description = request.Description,
                CategoryId = request.CategoryId,
                ImageUrl = request.ImageUrl,
                CreatedBy = identity.Identifier,
                CreatedDateTime = DateTimeOffset.Now
            };

            uow.Items.Create(item);
            await uow.SaveAsync();

            return new ResponseDto<int>
            {
                Succeed = true,
                Id = item.Id
            };
        }
    }
}
