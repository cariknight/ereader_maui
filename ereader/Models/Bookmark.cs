using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ereader.Models
{
    public class Bookmark
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Page { get; set; }
        public string Chapter { get; set; } = "";
        public string Position { get; set; } = "";
        public string PreviewString { get; set; } = "";

        public DateTime CreatedAt { get; set; }
    }
}
