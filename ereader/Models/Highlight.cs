using SQLite;
using System.Data;

namespace ereader.Models
{
    public class Highlight
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Text { get; set; } = "";
        public string Chapter { get; set; } = "";
        public string Position { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
