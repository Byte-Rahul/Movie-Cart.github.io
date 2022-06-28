using System.ComponentModel.DataAnnotations;

namespace Movie_Cart.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is Required.")]
        public string FullName { get; set; }

        [Display(Name ="Email Address")]
        [Required(ErrorMessage ="Email addres is Required.")]
        public string EmailAddress { get; set; }

       
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Passwords do not match")]
        public string ConfirmPassword { get; set; }
    }
}
