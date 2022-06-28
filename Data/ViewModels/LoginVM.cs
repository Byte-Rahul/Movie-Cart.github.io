using System.ComponentModel.DataAnnotations;

namespace Movie_Cart.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email addres is Required.")]
        public string EmailAddress { get; set; }

       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
