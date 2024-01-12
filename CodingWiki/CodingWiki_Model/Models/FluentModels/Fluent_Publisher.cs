using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    [Table("Fluent_Publishers")]
    public class Fluent_Publisher
    {
        [Key]
        public int Publisher_Id { get; set; }
        [Required(ErrorMessage = "Publisher name is required")]
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Fluent_Book> Books { get; set; }
    }
}
