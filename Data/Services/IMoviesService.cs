using Movie_Cart.Data.Base;
using Movie_Cart.Data.ViewModels;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Services
{
    public interface IMoviesService: IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMoviesDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM Data);
        Task UpdateMovieAsync(NewMovieVM Data);
    }
}
