using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    
    public class BookAuthorMap
    {
        [ForeignKey("Book")]
        public int Book_Id { get; set; }

        [ForeignKey("Author")]
        public int Author_Id { get; set; }

        public Book Book { get; set; }
        public Author Author { get; set; }
    }
}
