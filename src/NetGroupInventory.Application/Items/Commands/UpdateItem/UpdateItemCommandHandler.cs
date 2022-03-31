using MediatR;
using NetGroupInventory.Application.Common.Dtos;
using NetGroupInventory.Application.Interfaces;
using NetGroupInventory.Domain.Items;

namespace NetGroupInventory.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : BaseRequestHandler, IRequestHandler<UpdateItemCommand, ResponseDto>
    {
        public UpdateItemCommandHandler(IUnitOfWork uow, IUserIdentity identity) : base(uow, identity)
        {
        }

        public async Task<ResponseDto> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (uow.Items.HasTitle(request.Title, identity.Identifier, request.Id))
                return new ResponseDto
                {
                    Succeed = false,
                    Errors = new List<string> { "Item is already existing in the database" }
                };

            Item item = await uow.Items.GetById(request.Id);

            item.CategoryId = request.CategoryId;
            item.Title = request.Title;
            item.ImageUrl = request.ImageUrl;
            item.Description = request.Description;
            item.ModifiedBy = identity.Identifier;
            item.ModifiedDateTime = DateTimeOffset.Now;

            await uow.SaveAsync();

            return new ResponseDto
            {
                Succeed = true,
            };
        }
    }
}
