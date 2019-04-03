using System.ComponentModel.DataAnnotations;

namespace PieShop.Models
{
    public class Pie
    {
        //[BindNever]
        [Key]
        public int pie_id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string short_description { get; set; }

        [Display(Name = "Long Description")]
        public string long_description { get; set; }

        [Required]
        [Display(Name = "Price")]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999999, ErrorMessage = "Price must be greater than 0.00")]
        public double price { get; set; }

        [Display(Name = "Image URL")]
        [DataType(DataType.ImageUrl)]
        public string image_url { get; set; }

        [Display(Name = "Image Thumbnail URL")]
        [DataType(DataType.ImageUrl)]
        public string image_thumbnail_url { get; set; }

        [Display(Name = "Pie Of The Week ?")]
        public bool is_pie_of_the_week { get; set; }

        [Display(Name = "In Stock ?")]
        public bool is_in_stock { get; set; }

        public int category_id { get; set; }

        public virtual Category Category { get; set; }
    }
}
