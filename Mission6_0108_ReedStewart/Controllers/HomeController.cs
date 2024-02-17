using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        [HttpPost]
        public IActionResult MovieApplication(Application response) // Handle database submission
        {
            if (response.LentTo == null)
            {
                response.LentTo = "";
            }
            
            if (response.Notes == null)
            {
                response.Notes = "";
            }
            _context.Applications.Add(response); // Add record to the database
            _context.SaveChanges();
            return View("Confirmation", response);
        }

    }
}
