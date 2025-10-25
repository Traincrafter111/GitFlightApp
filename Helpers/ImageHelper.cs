using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitFlightApp.Helpers
{
    public static class ImageHelper
    {
        public static async Task<byte[]?> CapturePhotoAsync()
        {
            FileResult? photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                using var stream = await photo.OpenReadAsync();
                using var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
            return null;
        }

        public static ImageSource? ToImageSource(byte[]? bytesArray)
        {
            if(bytesArray != null && bytesArray.Length > 0)
            {
                return ImageSource.FromStream(() => new MemoryStream(bytesArray));
            }
            return null;
        }
    }
}
