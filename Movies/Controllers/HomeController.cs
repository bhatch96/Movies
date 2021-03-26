using Movies.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext Context { get; set; }

        //constructor
        public HomeController(MovieContext con)
        {
            Context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MovieList()
        {
            return View(new MovieListViewModel
            {
                Movies = Context.Movies
            });
        }

        public IActionResult MyBlog()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovie(Movie newMovie)
        {
            if (ModelState.IsValid)
            {
                Context.Movies.Add(newMovie);
                Context.SaveChanges();
            }
            return View();
        }

        [HttpPost]
        public IActionResult GoToEdit(MovieListViewModel model)
        {
            Movie editedMovie = new Movie();

            editedMovie = Context.Movies.Find(model.MovieID);

            return View("EditMovie", editedMovie);
        }

        [HttpPost]
        public IActionResult EditMovie(Movie editedMovie)
        {

            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Category = editedMovie.Category;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Title = editedMovie.Title;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Director = editedMovie.Director;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Year = editedMovie.Year;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Rating = editedMovie.Rating;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Edited = editedMovie.Edited;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().LentTo = editedMovie.LentTo;
            Context.Movies.Where(m => m.MovieID == editedMovie.MovieID).FirstOrDefault().Notes = editedMovie.Notes;

            Context.SaveChanges();

            return View("MovieList", new MovieListViewModel 
            {
                Movies = Context.Movies
            });
        }

        [HttpPost]
        public IActionResult RemoveMovie(MovieListViewModel model)
        {
            Context.Movies.Remove(Context.Movies.Find(model.MovieID));

            Context.SaveChanges();

            return View("MovieList", new MovieListViewModel
            {
                Movies = Context.Movies
            });
        }


    }
}
