using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Pragma.AdminCoreMvc.Helper
{
    public class UploadFileProcessor : IUploadFileProcessor
    {
        public async Task SaveImage(IFormFile image, string imageUploadBaseUrl, string fileName, string location)
        {
            if (image != null && image.Length > 0)
            {
                var filePath = Path.Combine(imageUploadBaseUrl, location, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }
            }
        }
    }

    public interface IUploadFileProcessor
    {
    }
}
