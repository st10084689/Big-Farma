using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Big_Farma.Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        public string ProductName { get; set; }

        public string ProductDescription { get; set; }

        public int Price{ get; set; }

        public int MyProperty { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category category { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("users")]
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [Required]
        public string users { get; set; }


    }
}
