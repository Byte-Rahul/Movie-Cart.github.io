using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Movie_Cart.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="Name")]
        public string FullName { get; set; }
    }
}
