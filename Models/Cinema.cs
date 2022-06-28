using Movie_Cart.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Movie_Cart.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Logo is required")]
        [Display(Name ="Cinema Logo")]
        public String? Logo { get; set; }

        [Required(ErrorMessage = "Cinema name is required")]
        [Display(Name ="Cinema Name")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "Cinema description is required")]
        public String? Description { get; set; }

        //Relationship
        public List<Movie>? Movies { get; set; }
    }
}
