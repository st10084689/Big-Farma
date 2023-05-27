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

        public int Price { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;

        public int MyProperty { get; set; }

        [ValidateNever]
        public string? ImageUrl { get; set; }

        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category category { get; set; }
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("ApplicationIdentity")]
        [ValidateNever]
        public ApplicationUser applicationUser { get; set; }
        [ValidateNever]
        public string ApplicationIdentity { get; set; }


    }
}
