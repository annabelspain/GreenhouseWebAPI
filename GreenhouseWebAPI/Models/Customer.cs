using System.ComponentModel.DataAnnotations;

namespace GreenhouseWebAPI.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [MaxLength(25, ErrorMessage = "Length of description cannot be greater than 25 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Birthday Required")]
        public int? Birthday { get; set; }

    }
}
