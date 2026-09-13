using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace ereader.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";
        public string FilePath { get; set; } = "";
        public string FileType { get; set; } = "";
        public string CoverPath { get; set; } = "";
        public double Progress { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentChapter { get; set; }
        public DateTime LastRead { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
