using MediatR;
using NetGroupInventory.Application.Interfaces.Clients;

namespace NetGroupInventory.Application.Files.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommand, UploadResponse>
    {
        readonly IFileStorageClient storageClient;

        public UploadFileCommandHandler(IFileStorageClient storageClient)
        {
            this.storageClient = storageClient;
        }

        public async Task<UploadResponse> Handle(UploadFileCommand request, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string newName = Guid.NewGuid() + Path.GetExtension(request.FileName);

            return new UploadResponse
            {
                UploadedUrl = await storageClient.Upload(newName, request.Container, request.FileStream)
            };
        }
    }
}
