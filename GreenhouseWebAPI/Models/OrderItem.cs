using System.ComponentModel.DataAnnotations;

namespace GreenhouseWebAPI.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderId { get; set; }

        public int GreenhouseId { get; set; }
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]
        [MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Status is required")]
        public string? Status { get; set; }
    }
}

