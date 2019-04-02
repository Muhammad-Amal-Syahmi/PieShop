using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PieShop.Models
{
    public class Pie
    {
        //[BindNever]
        [Key]
        public int pie_id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string short_description { get; set; }

        public string long_description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double price { get; set; }

        public string image_url { get; set; }
        public string image_thumbnail_url { get; set; }
        public bool is_pie_of_the_week { get; set; }
        public bool is_in_stock { get; set; }
        public int category_id { get; set; }
        public virtual Category Category { get; set; }
    }
}
