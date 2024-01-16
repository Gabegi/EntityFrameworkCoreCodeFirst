using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    public class Fluent_Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        [MaxLength(100)]
        public string ISBN { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public string PriceRange { get; set; }

        public Fluent_BookDetail BookDetail { get; set; }

        public int Publisher_Id { get; set; }
        public Fluent_Publisher Publisher { get; set; }

        //public List<Fluent_Author>Authors{ get; set; }

        public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
