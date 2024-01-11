using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    public class Book
    {
        // [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        [MaxLength(100)]
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public string PriceRange { get; set; }

        [ForeignKey("BookDetail")]
        public int BookDetail_Id { get; set; }
        public BookDetail BookDetail { get; set; }
    }
}
