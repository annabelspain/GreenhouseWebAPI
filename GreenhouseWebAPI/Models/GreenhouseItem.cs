using System.ComponentModel.DataAnnotations;

namespace GreenhouseWebAPI.Models
{
    public class GreenhouseItem
    {
        [Key]
        public int GreenhouseId { get; set; }

        [Required(ErrorMessage = "Plant Required")]
        [MaxLength(25, ErrorMessage = "Length of description cannot be greater than 25 characters")]
        public string? Plant { get; set; }

        [Required(ErrorMessage = "Age Required")]
        public int? Age { get; set; }

        [Required(ErrorMessage ="Order Required")]
        public string? Order { get; set; }
        /*

        [Required(ErrorMessage = "Price Required")]
        public double? Price { get; set; }
        */

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; }
    }
}
