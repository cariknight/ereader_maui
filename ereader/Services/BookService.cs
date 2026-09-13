using ereader.Data;
using ereader.Models;

namespace ereader.Services
{
    public class BookService
    {
        private readonly DatabaseService _database;
        private readonly FileService _fileService;

        public BookService(DatabaseService database, FileService fileService)
        {
            _database = database;
            _fileService = fileService;
        }

        public async Task<Book?> ImportBookAsync()
        {
            string? path = await _fileService.PickBookAsync();
            if (string.IsNullOrWhiteSpace(path)) return null;

            string extension = Path.GetExtension(path).TrimStart('.').ToUpperInvariant();
            string filename = Path.GetFileNameWithoutExtension(path);

            var book = new Book
            {
                Title = filename,
                Author = "Unknown Author",
                FilePath = path,
                FileType = extension,
                Progress = 0,
                CurrentPage = 0,
                CurrentChapter = 0,
                LastRead = DateTime.Now,
                DateAdded = DateTime.Now,
            };

            await _database.SaveBookAsync(book);
            return book;
        }

        public Task<List<Book>> GetBooksAsync()
        {
            return _database.GetBooksAsync();
        }

        public Task<Book?> GetBookAsync(int id)
        {
            return _database.GetBookAsync(id);
        }

        public Task SaveBookAsync(Book book)
        {
            return _database.SaveBookAsync(book);
        }
    }
}
