using ShoppingCartWebApi.Models;
using System.IO;

namespace ShoppingCartWebApi.Services
{
	public interface IFileServices
	{
		Task<string> Upload(FileModel fileModel);
		Task<Stream> Get(String name);
	}
}
