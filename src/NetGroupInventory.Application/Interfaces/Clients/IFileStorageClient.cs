namespace NetGroupInventory.Application.Interfaces.Clients
{
    public interface IFileStorageClient
    {
        Task<string> Upload(string fileName, string container, Stream fileStream);

        Task Delete(string container, string fileName);
    }
}
