using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    public class Fluent_BookDetail
    {
        [Key]
        public int BookDetail_Id { get; set; }
        public int NumberOfChapters { get; set; }
        public int NumberOfPages { get; set; }
        public string Weight { get; set; }

        public int BookId { get; set; }

        public Fluent_Book Book { get; set; }
    }
}
