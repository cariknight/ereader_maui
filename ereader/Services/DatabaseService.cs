using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using ereader.Models;

namespace ereader.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection? _database;

        private async Task InitAsync()
        {
            if (_database != null)
                return;
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, "ereader.db3");
            _database = new SQLiteAsyncConnection(databasePath);

            await _database.CreateTableAsync<Book>();
            await _database.CreateTableAsync<Bookmark>();
            await _database.CreateTableAsync<Highlight>();

        }

        // BOOKS
        public async Task<List<Book>> GetBooksAsync()
        {
            await InitAsync();

            return await _database!.Table<Book>().OrderByDescending(b => b.LastRead).ToListAsync();
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            await InitAsync();

            return await _database!.Table<Book>().Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveBookAsync(Book book)
        {
            await InitAsync();
            if (book.Id == 0)
            {
                return await _database!.InsertAsync(book);
            }

            return await _database!.UpdateAsync(book);
        }

        public async Task<int> DeleteBookAsync(Book book)
        {
            await InitAsync();
            return await _database!.DeleteAsync(book);
        }

        // BOOKMARKS

        public async Task<List<Bookmark>> GetBookmarksAsync(int bookId)
        {
            await InitAsync();
            return await _database!.Table<Bookmark>().Where(x => x.BookId == bookId).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<int> SaveBookmarkAsync(Bookmark bookmark)
        {
            await InitAsync();
            if (bookmark.Id ==0)
                return await _database!.InsertAsync(bookmark);
            return await _database!.UpdateAsync(bookmark);
        }

        public async Task<int> DeleteBookmarkAsync(Bookmark bookmark)
        {
            await InitAsync();
            return await _database!.DeleteAsync(bookmark);
        }

        // HIGHLIGHTS

        public async Task<List<Highlight>> GetHighlightsAsync(int bookId)
        {
            await InitAsync();
            return await _database!.Table<Highlight>().Where(x => x.BookId == bookId).OrderByDescending(x => x.CreatedAt).ToListAsync();
        }

        public async Task<int> SaveHighlightAsync(Highlight highlight)
        {
            await InitAsync();
            if (highlight.Id == 0)
                return await _database!.InsertAsync(highlight);
            return await _database!.UpdateAsync(highlight);
        }

        public async Task<int> DeleteHighlightAsync(Highlight highlight)
        {
            await InitAsync();
            return await _database!.DeleteAsync(highlight);
        }
    }
}
