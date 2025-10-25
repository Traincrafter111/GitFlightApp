namespace GitFlightApp.Helpers
{
    public static class ImageHelper
    {
        public static async Task<byte[]?> CapturePhotoAsync()
        {
            FileResult? photo = await MediaPicker.CapturePhotoAsync();
            if (photo == null) return null;

            using var stream = await photo.OpenReadAsync();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            return memoryStream.ToArray();


        }

        public static ImageSource? ToImageSource(byte[]? bytesArray)
        {
            if (bytesArray == null) return null;

            return ImageSource.FromStream(() => new MemoryStream(bytesArray));


        }

        public static async Task<string?> SaveImageLocalAsync(FileResult file)
        {
            if (file == null) return null;
            var newFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var localPath = Path.Combine(FileSystem.AppDataDirectory, newFileName);
            using var sourceStream = await file.OpenReadAsync();
            using var localFileStream = File.OpenWrite(localPath);
            await sourceStream.CopyToAsync(localFileStream);
            return localPath;
        }
    }
}
