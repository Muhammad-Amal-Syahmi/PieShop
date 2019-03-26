using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PieShop.Models
{
    public class Pie
    {
        [BindNever]
        public int PieId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double Price { get; set; }

        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }
        public bool IsInStock { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
