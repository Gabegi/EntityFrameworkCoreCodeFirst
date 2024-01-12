using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingWiki_Model.Models
{
    [Table("Categories")]
    public class Category
    {
        public int CategoryId { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public int DiscountedPrice { get; set; }

        [Column("Name")]
        [Required (ErrorMessage = "Genre name is required")]
        public string CategoryName { get; set; }
        // public int DisplayOrder { get; set; }
    }
}
