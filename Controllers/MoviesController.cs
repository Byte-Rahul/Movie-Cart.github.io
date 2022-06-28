using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_Cart.Data;
using Movie_Cart.Data.Services;
using Movie_Cart.Models;

namespace Movie_Cart.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        public MoviesController(IMoviesService service)
        {
            _service=service;
        }

        public async Task<IActionResult> Index()
        {
            var allMovies = await _service.GetAllAsync(x=>x.Cinema);
            return View(allMovies);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await _service.GetAllAsync(x => x.Cinema);
            if(!string.IsNullOrEmpty(searchString))
            {
                var result = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                    return View("Index",result);
            }
            return View("Index",allMovies);
        }

        //Get: Details
        public async Task<IActionResult> Details(int id)
        {
            var allMovies = await _service.GetMovieByIdAsync(id);
            return View(allMovies);
        }
        public async Task<IActionResult> Create()
        {
            var movieDropdownsData = await _service.GetNewMoviesDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas,"Id","Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            return View();


        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMoviesDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                return View(movie);
            }
            await _service.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
            var response = new NewMovieVM()
            {
                Id = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerId = movieDetails.ProducerId,
                ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };


            var movieDropdownsData = await _service.GetNewMoviesDropdownsValues();
            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
            ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
            return View(response);


        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");   
            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMoviesDropdownsValues();
                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                return View(movie);
            }
            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));

        }
    }
}
