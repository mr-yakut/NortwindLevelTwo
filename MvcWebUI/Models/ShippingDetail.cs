using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        [Required(ErrorMessage = "Required space!")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required space!")]
        [DataType(DataType.Text)]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required space!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required space!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Required space!")]
        [MinLength(10, ErrorMessage = "It should be at least 10 characters long.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Required space!")]
        [Range(18, 65)]
        public int Age { get; set; }
    }
}
