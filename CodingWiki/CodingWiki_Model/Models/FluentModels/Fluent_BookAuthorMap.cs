using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    
    public class Fluent_BookAuthorMap
    {
        // [ForeignKey("Book")]
        [Key]
        public int Book_Id { get; set; }

         // [ForeignKey("Author")]
        public int Author_Id { get; set; }

        public Fluent_Book Book { get; set; }
        public Fluent_Author Author { get; set; }
    }
}
