using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models
{
    [Table("Authors")]
    public class Author
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

    }
}
