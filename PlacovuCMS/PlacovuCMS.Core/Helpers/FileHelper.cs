using Microsoft.AspNetCore.Http;
using System.IO;

namespace PlacovuCMS.Core.Helpers
{
    public static class FileHelper
    {
        public static byte[] ConvertToBytes(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.OpenReadStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
