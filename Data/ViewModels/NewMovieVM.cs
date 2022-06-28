using Movie_Cart.Data.Base;
using Movie_Cart.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Cart.Models
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Movie name is Required")]
        [Display(Name ="Movie Name")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Movie description is Required")]
        [Display(Name = "Movie Description")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Display(Name = "Price")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Movie Image Url is Required")]
        [Display(Name = "Poster Url")]
        public String ImageUrl { get; set; }

        [Required(ErrorMessage = "Movie Start date is Required")]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Movie End date is Required")]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Movie category is Required")]
        [Display(Name = "Movie Category")]
        public MovieCategory MovieCategory { get; set; }

        //RElationship

        [Required(ErrorMessage = "Select Movie Actors")]
        [Display(Name = "Actor")]
        public List<int> ActorIds { get; set; }

        //Cinema

        [Required(ErrorMessage = "Select a Cinema")]
        [Display(Name = "Cinema")]
        public int CinemaId { get; set; }


        //Producer

        [Required(ErrorMessage = "Select Movie Producer")]
        [Display(Name = "Producer")]
        public int ProducerId { get; set; }
        
    }
}
