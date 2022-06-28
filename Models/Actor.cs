using Movie_Cart.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace Movie_Cart.Models
{
    public class Actor: IEntityBase
    {
        [Key]
        public int Id { get; set; }
        
        [Display(Name ="Profile Picture Url")]
        [Required(ErrorMessage ="Profile Picture is required")]
        public String? ProfilePicureUrl { get; set; }
        
        [Display(Name ="Name")]
        [Required(ErrorMessage ="Name is required")]
        [StringLength(50, MinimumLength =3, ErrorMessage ="Name must be between 3 to 50 chars")]
        public String? FullName { get; set; }

        [Required(ErrorMessage ="Bio is required")]
        [Display(Name ="Biography")]
        public String? Bio { get; set; }

        //Relationship
        public List <Actor_Movie>? Actors_Movies { get; set; }
    }
}
