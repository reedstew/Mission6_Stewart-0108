using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_0108_ReedStewart.Models;
using System.Diagnostics;

namespace Mission6_0108_ReedStewart.Controllers
{
    public class HomeController : Controller
    {
        private MovieApplicationContext _context;
        public HomeController(MovieApplicationContext temp) //Constructor
        {
            _context = temp;
        }

        public IActionResult Index() //Home page view
        {
            return View();
        }

        public IActionResult GetJoel() //Get to know Joel view
        {
            return View();
        }
        [HttpGet]
        public IActionResult MovieApplication() //Submit a movie review view
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieApplication", new Movie(){ CopiedToPlex=0, Edited=0, Title="", Year=0}); // It requires some attribute values to bring back an ID
        }
        [HttpPost]
        public IActionResult MovieApplication(Movie response) // Handle database submission
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); // Add record to the database
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else //Invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _context.Movies
                .Include(m => m.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("MovieApplication", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Movie m)
        {
            _context.Update(m);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie m)
        {
            _context.Movies.Remove(m);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }

    }
}
