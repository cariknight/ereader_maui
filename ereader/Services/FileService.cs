namespace ereader.Services
{
    public class FileService
    {
        public async Task<string?> PickBookAsync()
        {
            var result = await FilePicker.Default.PickAsync(
                new PickOptions
                {
                    PickerTitle = "Choose a book",
                    FileTypes = new FilePickerFileType(
                        new Dictionary<DevicePlatform, IEnumerable<string>>
                        {
                            {
                                DevicePlatform.WinUI,
                                new []
                                {
                                    ".epub",
                                    ".pdf",
                                    ".txt",
                                }
                            },
                            {
                                DevicePlatform.Android,
                                new[]
                                {
                                    "application/epub+zip",
                                    "application/pdf",
                                    "text/plain"
                                }
                            }
                        })
                }
                );
            if (result == null) return null;

            string extension = Path.GetExtension(result.FileName).ToLowerInvariant();
            string destination = Path.Combine(FileSystem.AppDataDirectory, "Books");
            Directory.CreateDirectory(destination);

            string destinationPath = Path.Combine(destination, $"{Guid.NewGuid()}{extension}");

            using Stream source = await result.OpenReadAsync();
            using FileStream destinationStream = File.Create(destinationPath);

            await source.CopyToAsync(destinationStream);
            return destinationPath;
        }
    }
}
