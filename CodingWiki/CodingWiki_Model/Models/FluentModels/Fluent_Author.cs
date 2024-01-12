using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    [Table("Fluent_Authors")]
    public class Fluent_Author
    {
        [Key] 
        public int Author_Id { get; set; }
        [MaxLength(50)]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Location { get; set; }
        [NotMapped]
        public  string FullName 
        { get
            {
                return FirstName + " " + LastName;
            }
        }
        //public List<Fluent_Book> Books { get; set; }

        // public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }

    }
}
