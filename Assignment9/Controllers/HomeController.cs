using Assignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment9.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //Thi is the variable that will allow us to call the DbContext to display information
        private MovieDbContext context { get; set; }

        //This is the contructor for the home controller where we have to had the context = con in the home controller to pull in the database
        public HomeController(MovieDbContext con)
        {
            context = con;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        //This is the Http Get that is returned when we initially call the New Movie View
        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        //This will be the Http post that will save the changes to the database that will allow us to view the information
        [HttpPost]
        public IActionResult NewMovie(Movie m)
        {
            //This will add the movie that was just entered into the database
            context.Movies.Add(m);

            //This will save the changes made to the database
            context.SaveChanges();

            return View("Index");
        }

        public IActionResult TotalMovieList()
        {
            return View(context.Movies);
        }

        //Edit a movie
        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            var movie = context.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            return View(movie);
        }
        
        //This is the post for editing a movie
        [HttpPost]
        public IActionResult EditMovie(Movie m)
        {
            var MovieEdit = context.Movies.Where(x => x.MovieId == m.MovieId).FirstOrDefault();
            context.Movies.Remove(MovieEdit);
            context.Movies.Add(m);
            context.SaveChanges();

            return RedirectToAction("TotalMovieList", context.Movies);
        }

        //This is the action that we used to remove the movie from our view of all of the movies
        public IActionResult Remove(int id)
        {
            var MovieRemove = context.Movies.Where(x => x.MovieId == id).FirstOrDefault();
            context.Movies.Remove(MovieRemove);
            context.SaveChanges();
            return View("TotalMovieList", context.Movies);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
