using System.ComponentModel.DataAnnotations;

namespace Big_Farma.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Category")]
        [Required]
        public string CategoryName { get; set; }
    }
}
