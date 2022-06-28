using Microsoft.EntityFrameworkCore;
using Movie_Cart.Data.Base;
using Movie_Cart.Data.ViewModels;
using Movie_Cart.Models;

namespace Movie_Cart.Data.Services
{
    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _db;
        public MoviesService(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddNewMovieAsync(NewMovieVM Data)
        {
            var newMovie = new Movie()
            {
                Name = Data.Name,
                Description = Data.Description,
                Price = Data.Price,
                ImageUrl = Data.ImageUrl,
                CinemaId = Data.CinemaId,
                StartDate = Data.StartDate,
                EndDate = Data.EndDate,
                MovieCategory = Data.MovieCategory,
                ProducerId = Data.ProducerId

            };
            await _db.Movies.AddAsync(newMovie);
            await _db.SaveChangesAsync();

            foreach(var actorId in Data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _db.Actors_Movies.AddAsync(newActorMovie);
            };
            await _db.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _db.Movies
                .Include(c=>c.Cinema)
                .Include(p=>p.Producer)
                .Include(am=>am.Actors_Movies).ThenInclude(a=>a.Actor)
                .FirstOrDefaultAsync(x=>x.Id== id);
            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMoviesDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
               Actors = await _db.Actors.OrderBy(n => n.FullName).ToListAsync(),
               Producers = await _db.Producers.OrderBy(n => n.FullName).ToListAsync(),
               Cinemas = await _db.Cinemas.OrderBy(n => n.Name).ToListAsync()
            };


            return response;
            
        }

        public async Task UpdateMovieAsync(NewMovieVM Data)
        {
            var dbMovie = await _db.Movies.FirstOrDefaultAsync(n=>n.Id== Data.Id);
            if (dbMovie == null)
            {
                dbMovie.Name = Data.Name;
                dbMovie.Description = Data.Description;
                dbMovie.Price = Data.Price;
                dbMovie.ImageUrl = Data.ImageUrl;
                dbMovie.CinemaId = Data.CinemaId;
                dbMovie.StartDate = Data.StartDate;
                dbMovie.EndDate = Data.EndDate;
                dbMovie.MovieCategory = Data.MovieCategory;
                dbMovie.ProducerId = Data.ProducerId;
                 await _db.SaveChangesAsync();
            }
            var existingActorsDb = dbMovie.Actors_Movies.Where(n => n.MovieId == Data.Id).ToList();
            _db.Actors_Movies.RemoveRange(existingActorsDb);
            await _db.SaveChangesAsync();

            
            
          

            foreach (var actorId in Data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = Data.Id,
                    ActorId = actorId
                };
                await _db.Actors_Movies.AddAsync(newActorMovie);
            };
            await _db.SaveChangesAsync();
        }
    }
}
