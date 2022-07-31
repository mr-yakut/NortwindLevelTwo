using System.ComponentModel.DataAnnotations;

namespace MvcWebUI.Models
{
    public class ShippingDetail
    {
        [Required(ErrorMessage = "İsim gerekli!")]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim gerekli!")]
        [DataType(DataType.Text)]
        [MaxLength(10)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Mail gerekli!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şehir gerekli!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Adres gerekli!")]
        [MinLength(10, ErrorMessage = "Minimim 10 karakter uzunluğunda olmalıdır.")]
        public string Adress { get; set; }
        [Required(ErrorMessage = "Yaş gerekli!")]
        [Range(18, 65)]
        public int Age { get; set; }
    }
}
