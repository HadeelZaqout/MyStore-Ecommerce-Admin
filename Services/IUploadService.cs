namespace MyStore.Services
{
    public interface IUploadService
    {
        string? Upload(IFormFile formFile , string subFolder = "Products");
    }
}
