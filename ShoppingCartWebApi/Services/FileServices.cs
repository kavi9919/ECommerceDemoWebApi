using Azure.Storage.Blobs;
using ShoppingCartWebApi.Models;

namespace ShoppingCartWebApi.Services
{
	public class FileServices:IFileServices
	{
		private readonly BlobServiceClient _blobServiceClient;

		public FileServices(BlobServiceClient blobServiceClient)
		{
			_blobServiceClient = blobServiceClient;
		}

		public async Task<string> Upload(FileModel fileModel)
		{
			// Generate a UUID
			string uuid = Guid.NewGuid().ToString();

			// Extracting file extension
			string fileExtension = Path.GetExtension(fileModel.ImageFile.FileName);

			// Construct new filename with UUID
			string newFileName = $"{uuid}{fileExtension}";

			// Create container instance
			var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

			// Create blob instance with the new filename
			var blobInstance = containerInstance.GetBlobClient(newFileName);

			// File save in storage
			await blobInstance.UploadAsync(fileModel.ImageFile.OpenReadStream());

			// Return the generated new filename
			return newFileName;
		}

		public async Task<Stream> Get(String name)
		{
			//create container instance
			var containerInstance = _blobServiceClient.GetBlobContainerClient("products");

			//create blob instance
			var blobInstance = containerInstance.GetBlobClient(name);

			var downloadContent = await blobInstance.DownloadAsync();

			return downloadContent.Value.Content;

		}
	}
}
