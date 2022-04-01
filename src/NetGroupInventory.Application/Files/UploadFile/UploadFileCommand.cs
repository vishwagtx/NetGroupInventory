using MediatR;

namespace NetGroupInventory.Application.Files.UploadFile
{
    public class UploadFileCommand: IRequest<UploadResponse>
    {
        public string Container { get; set; }
        public string FileName { get; set; }
        public Stream FileStream { get; set; }
    }
}
