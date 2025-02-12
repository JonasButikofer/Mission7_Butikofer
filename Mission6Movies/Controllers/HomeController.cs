using Microsoft.AspNetCore.Mvc;
using Mission6Movies.Models;
using System.Diagnostics;

namespace Mission6Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly FilmApplicationContext _context;
        private readonly ILogger<HomeController> _logger;

        // Single constructor to handle both dependencies
        public HomeController(FilmApplicationContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: /Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/GetToKnow
        public IActionResult GetToKnow()
        {
            return View();
        }

        // GET: /Home/Form
        public IActionResult Form()
        {
            return View(new FormModel());
        }

        // POST: /Home/Form
        [HttpPost]
        public IActionResult Form(FormModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Films.Add(model); // Adds a new film to the database
                _context.SaveChanges(); // Save the changes to the database

                string movieName = model.MovieName;
                string rating = model.Rating;

                TempData["SuccessMessage"] = "Form submitted successfully! " + "Movie Name: " + movieName + " and the rating is: " + rating;
                return RedirectToAction("Form");  // Redirect back to the form view
            }

            return View(model);  // Return the model if validation fails
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

